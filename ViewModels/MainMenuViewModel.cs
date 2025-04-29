using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariableSapper.ViewModels.Base;

namespace VariableSapper.ViewModels
{
    internal class MainMenuViewModel : ViewModel
    {
        readonly MainWindowViewModel _windowVM;



        public MainMenuViewModel(MainWindowViewModel windowVM)
        {
            _windowVM = windowVM;
        }
    }
}
