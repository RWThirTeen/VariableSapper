using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VariableSapper.Infrastructure.Commands;
using VariableSapper.Interfacees.FieldConstructor;
using VariableSapper.Models.FieldConstructorElements;
using VariableSapper.Models.FieldElements;
using VariableSapper.ViewModels.Base;

namespace VariableSapper.ViewModels
{
    internal class MainMenuViewModel : ViewModel
    {
        readonly MainWindowViewModel _windowVM;

        void StartNewGame(int row, int column, int mines)
        {
            IFieldConstructor constructor = new FieldConstructor();
            MineField field = constructor.CreateField(row, column, mines);

            _windowVM.ChangeCurrentView("field");

            FieldViewModel VM = _windowVM.CurrentViewModel as FieldViewModel;
            VM.MineField = field;
        }

        #region StartGameButtons

        public ICommand StartEasyGameCommand { get; }
        public ICommand StartMediumGameCommand { get; }
        public ICommand StartHardGameCommand { get; }
        public ICommand StartCustomGameCommand { get; }

        void OnStartEasyGameCommandExecuted(object p)
        {
            StartNewGame(10, 10, 10);
        }
        void OnStartMediumGameCommandExecuted(object p)
        {
            StartNewGame(16, 16, 40);
        }
        void OnStartHardGameCommandExecuted(object p)
        {
            StartNewGame(16, 30, 100);
        }
        void OnStartCustomGameCommandExecuted(object p)
        {
            StartNewGame(CustomRows, CustomColumns, CustomMinesCount);
        }

        bool CanStartEasyGameCommandExecute(object p) => true;
        bool CanStartMediumGameCommandExecute(object p) => true;
        bool CanStartHardGameCommandExecute(object p) => true;
        bool CanStartCustomGameCommandExecute(object p)
        {
            if (CustomRows <= 10 || CustomColumns <= 10 || CustomMinesCount <= 10 || CustomMinesCount >= CustomRows * CustomColumns) return false;
            return true;
        }

        #endregion

        #region CustomGameSetupFields

        int _customRows = 10;
        int _customColumns = 10;
        int _customMinesCount = 10;

        public int CustomRows
        {
            get => _customRows;
            set
            {
                Set(ref _customRows, value);
                CalculateMinesCount();
            }

        }
        public int CustomColumns
        {
            get => _customColumns;
            set
            {
                Set(ref _customColumns, value);
                CalculateMinesCount();
            }

        }
        public int CustomMinesCount
        {
            get => _customMinesCount;
            set => Set(ref _customMinesCount, value);
        }


        #region SlidersFields

        int _maximumCustomRows;
        int _maximumCustomCollumns;
        int _maximumCustomMinesCount;
        int _minimumRecomendedMinesCount;
        int _maximunRecomendedMinesCount;
        int _rowsTick = 10;
        int _columnsTick = 10;
        int _minesCountTick = 10;

        public int MaximumCustomRows
        {
            get => _maximumCustomRows;
            set => Set(ref _maximumCustomRows, value);
        }
        public int MaximumCustomCollumns
        {
            get => _maximumCustomCollumns;
            set => Set(ref _maximumCustomCollumns, value);
        }
        public int MaximumCustomMinesCount
        {
            get => _maximumCustomMinesCount;
            set => Set(ref _maximumCustomMinesCount, value);
        }
        public int MinimumCustomRecomendedMinesCount
        {
            get => _minimumRecomendedMinesCount;
            set => Set(ref _minimumRecomendedMinesCount, value);
        }
        public int MaximumCustomRecomendedMinesCount
        {
            get => _maximunRecomendedMinesCount;
            set => Set(ref _maximunRecomendedMinesCount, value);
        }
        public int RowsTick
        {
            get => _rowsTick;
            set => Set(ref _rowsTick, value);
        }
        public int ColumnsTick
        {
            get => _columnsTick;
            set => Set(ref _columnsTick, value);
        }
        public int MinesCountTick
        {
            get => _minesCountTick;
            set => Set(ref _minesCountTick, value);
        }


        #endregion

        #endregion

        #region ExitButton

        public ICommand ExitApplicationCommand { get; } 
        private void OnExitApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanExitApplicationCommandExecute(object p) => true;

        #endregion

        #region HelpingMethods

        void CalculateMaximumSizeOfCustomField()
        {
            double monitorWidth = SystemParameters.FullPrimaryScreenWidth;
            double monitorHeight = SystemParameters.FullPrimaryScreenHeight;

            MaximumCustomRows = (int)Math.Floor(monitorHeight / 250) * 10;
            MaximumCustomCollumns = (int)Math.Floor(monitorWidth / 250) * 10;
        }

        void CalculateMinesCount()
        {
            int CellsInTotal = CustomColumns * CustomRows;

            MaximumCustomMinesCount = CellsInTotal - 5;
            MinimumCustomRecomendedMinesCount = (int)Math.Floor(MaximumCustomMinesCount * 0.125 / 10) * 10;
            MaximumCustomRecomendedMinesCount = (int)Math.Ceiling(MaximumCustomMinesCount * 0.206 / 10) * 10;
        }

        #endregion

        public MainMenuViewModel(MainWindowViewModel windowVM)
        {
            _windowVM = windowVM;

            _windowVM.SetCurrentViewSize(500,550);

            ExitApplicationCommand = new LambdaCommand(OnExitApplicationCommandExecuted, CanExitApplicationCommandExecute);

            StartEasyGameCommand = new LambdaCommand(OnStartEasyGameCommandExecuted, CanStartEasyGameCommandExecute);
            StartMediumGameCommand = new LambdaCommand(OnStartMediumGameCommandExecuted, CanStartMediumGameCommandExecute);
            StartHardGameCommand = new LambdaCommand(OnStartHardGameCommandExecuted, CanStartHardGameCommandExecute);
            StartCustomGameCommand = new LambdaCommand(OnStartCustomGameCommandExecuted, CanStartCustomGameCommandExecute);

            CalculateMaximumSizeOfCustomField();
            CalculateMinesCount();
        }
    }
}
