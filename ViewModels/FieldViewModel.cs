﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using VariableSapper.Infrastructure.Commands;
using VariableSapper.Interfacees.FieldConstructor;
using VariableSapper.Models.Enums;
using VariableSapper.Models.FieldConstructorElements;
using VariableSapper.Models.FieldElements;
using VariableSapper.ViewModels.Base;

namespace VariableSapper.ViewModels
{
    internal class FieldViewModel : ViewModel
    {
        readonly MainWindowViewModel _mainWindow;

        MineField _mineField;
        public MineField MineField
        {
            get => _mineField;
            set
            {
                //отписка от ячеек
                if (_mineField != null)
                {
                    foreach (Cell old_cell in Field)
                    {
                        old_cell.PropertyChanged -= OnCellChanged;
                    }
                }

                //обновление поля
                _mineField = null;

                Set(ref _mineField, value);


                //изменение размеров окна
                int calculatedwidth = MineField.NumberOfColumns * 30 + 20;
                int calculatedheight = MineField.NumberOfRows * 30 + 20;

                _mainWindow.SetCurrentViewSize(Math.Max(calculatedwidth,550), calculatedheight + 40);
                UserControlWidth = calculatedwidth;
                UserControlHeight = calculatedheight;

                //восстановление счетчиков
                _openedCellsCounter = 0;
                _safeCellsCount = Field.Count - MineCount;

                Watch = new Stopwatch();
                
                GameState = GameStatus.GameOn;

                //подписка на ячейки
                foreach (Cell cell in Field)
                {
                    cell.PropertyChanged += OnCellChanged;
                }

                OnPropertyChanged("Field");
            }
        }

        GameStatus _gameState;
        GameStatus GameState
        {
            get => _gameState;
            set
            {
                GameStatusText = value.ToString();

                if (value == GameStatus.GameOn)
                {
                    
                    Watch.Start();
                    StartTimer();
                }
                else StopTimer();

                Set(ref _gameState, value);
            }
        }

        public int MineCount 
        { 
            get
            {
                if (MineField.MinesCount <= 0) return 0;
                else return MineField.MinesCount;
            } 
        }

        public ObservableCollection<Cell> Field => MineField.Cells;

        void OnCellChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;
            object value = typeof(Cell).GetProperty(e.PropertyName);
        }

        string _gameStatusText;
        public string GameStatusText
        {
            get => _gameStatusText;
            set => Set(ref  _gameStatusText, value);
        }




        #region UserControlSize

        double _userControlWidth;
        double _userControlHeight;

        public double UserControlWidth
        {
            get => _userControlWidth;
            private set
            {
                if (value < 550) value = 550;
                Set(ref _userControlWidth, value);
            }
                
        }
        public double UserControlHeight
        {
            get => _userControlHeight;
            private set => Set(ref _userControlHeight, value);
        }

        #endregion


        #region Timer

        string _timer;
        public string Timer
        {
            get => _timer;
            set => Set(ref _timer, value);
        }

        Stopwatch Watch { get; set; }

        private CancellationTokenSource _cancellationtoken;

        private async Task RunLoopAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (true)
                {
                    Timer = Convert.ToString(Math.Round(Watch.Elapsed.TotalSeconds));
                    await Task.Delay(1000, cancellationToken);
                }
            }
            catch (OperationCanceledException) { }
        }

        private async void StartTimer()
        {
            if (_cancellationtoken != null) return;

            try
            {
                using (_cancellationtoken = new CancellationTokenSource())
                {
                    await RunLoopAsync(_cancellationtoken.Token);
                }
            }
            catch(Exception ex)
            {

            }
            _cancellationtoken = null;
        }

        void StopTimer()
        {
            _cancellationtoken?.Cancel();
        }

        #endregion


        #region ViewCommands

        public ICommand ApplicationExitCommand { get; }
        void OnApplicationExitCommandExecuted(object p)
        {
            App.Current.Shutdown();
        }
        bool CanApplicationExitCommandExecute(object p) => true;

        public ICommand BackToMenuCommand { get; }
        void OnBackToMenuCommandExecuted(object p)
        {
            _mainWindow.ChangeCurrentView("menu");
            _mainWindow.SetCurrentViewSize(500,550);
        }
        bool CanBackToMenuCommandExecute(object p) => true;

        public ICommand RestartGameCommand { get; }
        void OnRestartGameCommandExecuted(object p)
        {
            IFieldConstructor constructor = new FieldConstructor();
            MineField field = constructor.CreateField(MineField.NumberOfRows, MineField.NumberOfColumns, MineField.StartMinesCount);

            MineField = field;

            foreach (Cell c in Field) ;

            //обновление вида
        }
        bool CanRestartGameCommandExecute(object p) => true;

        #endregion


        #region Логика нажатия на ячйеки

        public ICommand OpenCellCommand { get; }
        void OnOpenCellCommandExecuted(object p)
        {
            if (GameState != GameStatus.GameOn) return;

            Button button = (Button)p;
            Cell cell = button.DataContext as Cell;

            OpenCell(cell);
        }

        

        bool CanOpenCellCommandExecute(object p) => true;

        public ICommand SetFlagCommand { get; }
        void OnSetFlagCommandExecuted(object p)
        {
            if (GameState != GameStatus.GameOn) return;

            Button button = (Button)p;

            Cell cell = button.DataContext as Cell;

            if (cell.IsOpen) return;

            MineField.ChangeMinesCount(cell.IsFlaged);

            cell.ChangeFlagedStatus();

            OnPropertyChanged("MineCount");
        }
        bool CanSetFlagCommandExecute(object p) => true;

        #endregion


        #region Проверка условия победы


        int _openedCellsCounter;
        int _safeCellsCount;

        bool CheckVictoryConditions()
        {
            if (_openedCellsCounter == _safeCellsCount) return true;

            return false;
        }


        #endregion





        #region Open Cell Methods

        void OpenCell(Cell cell)
        {
            if (cell.IsFlaged || cell.IsOpen) return;

            if (cell.IsMine)
            {
                OpenAllCellsCommand.Execute(cell);

                GameState = GameStatus.Lose;


                return;
            }

            cell.SetAsOpen();
            _openedCellsCounter++;

            if (cell.MinesCountAround == 0) OpenCellsAround(cell);

            if (CheckVictoryConditions()) GameState = GameStatus.Win; //вывод победного окна 
        }



        void OpenCellsAround(Cell cell)
        {
            //верхний ряд
            if (cell.Row == 0)
            {
                //левая ячейка
                if (cell.Column == 0)
                {
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column + 1]);
                }

                //средние ячейки
                if (cell.Column > 0 && cell.Column < MineField.NumberOfColumns - 1)
                {
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column + 1]);
                }

                //правая ячейка
                if (cell.Column == MineField.NumberOfColumns - 1)
                {
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column]);
                }
            }

            //средние ряды
            if (cell.Row > 0 && cell.Row < MineField.NumberOfRows - 1)
            {
                //левая ячейка
                if (cell.Column == 0)
                {
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column + 1]);
                }

                //средние ячейки
                if (cell.Column > 0 && cell.Column < MineField.NumberOfColumns - 1)
                {
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column + 1]);
                }

                //правая ячейка
                if (cell.Column == MineField.NumberOfColumns - 1)
                {
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row + 1) * MineField.NumberOfColumns + cell.Column]);
                }
            }

            //нижний ряд
            if (cell.Row == MineField.NumberOfRows - 1)
            {
                //левая ячейка
                if (cell.Column == 0)
                {
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column + 1]);
                }

                //средние ячейки
                if (cell.Column > 0 && cell.Column < MineField.NumberOfColumns - 1)
                {
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column + 1]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column + 1]);
                }

                //правая ячейка
                if (cell.Column == MineField.NumberOfColumns - 1)
                {
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column - 1]);
                    OpenCell(Field[(cell.Row - 1) * MineField.NumberOfColumns + cell.Column]);
                    OpenCell(Field[cell.Row * MineField.NumberOfColumns + cell.Column - 1]);
                }
            }
        }


        #endregion


        public ICommand OpenAllCellsCommand { get; }
        void OnOpenAllCellsCommandExecuted(object p)
        {
            foreach (Cell c in Field)
            {
                c.SetAsOpen();
            }
        }
        bool CanOpenAllCellsCommandExecute(object p) => true;


        public FieldViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;

            ApplicationExitCommand = new LambdaCommand(OnApplicationExitCommandExecuted, CanApplicationExitCommandExecute);
            BackToMenuCommand = new LambdaCommand(OnBackToMenuCommandExecuted, CanBackToMenuCommandExecute);
            RestartGameCommand = new LambdaCommand(OnRestartGameCommandExecuted, CanRestartGameCommandExecute);

            OpenCellCommand = new LambdaCommand(OnOpenCellCommandExecuted, CanOpenCellCommandExecute);
            SetFlagCommand = new LambdaCommand(OnSetFlagCommandExecuted, CanSetFlagCommandExecute);
            OpenAllCellsCommand = new LambdaCommand(OnOpenAllCellsCommandExecuted, CanOpenAllCellsCommandExecute);
        }
    }
}
