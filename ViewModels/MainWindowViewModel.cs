using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VariableSapper.ViewModels.Base;
using VariableSapper.Views;

namespace VariableSapper.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region WindowState

        string _windowTitle = "Sapper";
        public string WindowTitle
        {
            get => _windowTitle;
            set => Set(ref  _windowTitle, value);
        }

        #endregion


        Dictionary<string, FrameworkElement> _viewsDictionary;
        Dictionary<string, ViewModel> _viewModelsDictionary;


        #region CurrentView

        private ViewModel _currentViewModel;
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        #region CurrentView_Size

        private double _currentView_Width = 250;
        public double CurrentView_Width
        {
            get => _currentView_Width;
            private set => Set(ref _currentView_Width, value);
        }

        private double _currentView_Height = 250;
        public double CurrentView_Height
        {
            get => _currentView_Height;
            private set => Set(ref _currentView_Height, value);
        } 

        public void SetCurrentViewSize(double width, double height)
        {
            if (width <= 0 || height <= 0) return; //сообщение об ошибке

            CurrentView_Width = width;
            CurrentView_Height = height;
        }

        #endregion




        public void ChangeCurrentView(string name)
        {
            if (name == null || name == "") return; // прописать вывод ошибки

            if (!_viewModelsDictionary.ContainsKey(name))
            {
                CreateNewView(name);
            }

            //CurrentView = _viewsDictionary[name];
            //CurrentView.DataContext = _viewModelsDictionary[name];
            CurrentViewModel = _viewModelsDictionary[name];

            OnPropertyChanged("CurrentView");
        }

        void CreateNewView(string name)
        {
            switch (name)
            {
                default: break;

                case "menu":
                    _viewModelsDictionary.Add(name, new MainMenuViewModel(this));
                    break;
                case "field":
                    _viewModelsDictionary.Add(name, new FieldViewModel(this));
                    break;
            }
        }

        #endregion




        public MainWindowViewModel()
        {
            _viewsDictionary = new Dictionary<string, FrameworkElement>();
            _viewModelsDictionary = new Dictionary<string, ViewModel>();

            ChangeCurrentView("menu");
        }
    }
}
