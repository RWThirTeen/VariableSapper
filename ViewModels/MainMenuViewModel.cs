using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VariableSapper.Infrastructure.Commands;
using VariableSapper.ViewModels.Base;

namespace VariableSapper.ViewModels
{
    internal class MainMenuViewModel : ViewModel
    {
        readonly MainWindowViewModel _windowVM;

        void StartNewGame(int row, int column, int mines)
        {

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
            StartNewGame(16, 30, 99);
        }
        void OnStartCustomGameCommandExecuted(object p)
        {
            StartNewGame(CustomRows,CustomColumns,CustomMinesCount);
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

        int _customRows;
        int _customColumns;
        int _customMinesCount;

        public int CustomRows
        {
            get => _customRows;
            set => Set(ref _customRows, value);
        }
        public int CustomColumns
        {
            get => _customColumns;
            set => Set(ref _customColumns, value);
        }
        public int CustomMinesCount
        {
            get => _customMinesCount;
            set => Set(ref _customMinesCount, value);
        }

        #endregion

        #region ExitButton

        public ICommand ExitApplicationCommand { get; } 
        private void OnExitApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanExitApplicationCommandExecute(object p) => true;

        #endregion

        public MainMenuViewModel(MainWindowViewModel windowVM)
        {
            _windowVM = windowVM;

            ExitApplicationCommand = new LambdaCommand(OnExitApplicationCommandExecuted, CanExitApplicationCommandExecute);

            StartEasyGameCommand = new LambdaCommand(OnStartEasyGameCommandExecuted, CanStartEasyGameCommandExecute);
            StartMediumGameCommand = new LambdaCommand(OnStartMediumGameCommandExecuted, CanStartMediumGameCommandExecute);
            StartHardGameCommand = new LambdaCommand(OnStartHardGameCommandExecuted, CanStartHardGameCommandExecute);
            StartCustomGameCommand = new LambdaCommand(OnStartCustomGameCommandExecuted, CanStartCustomGameCommandExecute);
        }
    }
}
