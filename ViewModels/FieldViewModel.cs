using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Shapes;
using VariableSapper.Infrastructure.Commands;
using VariableSapper.Interfacees.FieldConstructor;
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
                Set(ref _mineField, value);

                int calculatedwidth = MineField.NumberOfColumns * 30 + 20;
                int calculatedheight = MineField.NumberOfRows * 30 + 20;

                _mainWindow.SetCurrentViewSize(Math.Max(calculatedwidth,550), calculatedheight + 40);
                UserControlWidth = calculatedwidth;
                UserControlHeight = calculatedheight;
            }
        }

        public int MineCount => MineField.MinesCount;

        


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

        int _timer;
        public int Timer
        {
            get => _timer;
            set => Set(ref _timer, value);
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
            Timer = 0;

            // нужно ли обновление вида?
        }
        bool CanRestartGameCommandExecute(object p) => true;

        #endregion

        public FieldViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;

            ApplicationExitCommand = new LambdaCommand(OnApplicationExitCommandExecuted, CanApplicationExitCommandExecute);
            BackToMenuCommand = new LambdaCommand(OnBackToMenuCommandExecuted, CanBackToMenuCommandExecute);
            RestartGameCommand = new LambdaCommand(OnRestartGameCommandExecuted, CanRestartGameCommandExecute);
        }
    }
}
