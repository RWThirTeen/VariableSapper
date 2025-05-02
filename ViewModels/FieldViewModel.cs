using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                _mainWindow.SetCurrentViewSize(MineField.Columns * 25 + 20, MineField.Rows * 25 + 60);
            }
        }

        public int MineCount => MineField.MinesCount;
        

        #region Timer

        int _timer;
        public int Timer
        {
            get => _timer;
            set => Set(ref _timer, value);
        }

        #endregion




        public FieldViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindow = mainWindowViewModel;
        }
    }
}
