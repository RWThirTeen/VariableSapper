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

        //double _windowWidth = 250;
        //double _windowHeight = 250;

        //public double WindowWidth
        //{
        //    get => _windowWidth;
        //    private set => Set(ref _windowWidth, value);
        //}
        //public double WindowHeight
        //{
        //    get => _windowHeight; 
        //    private set => Set(ref _windowHeight, value);
        //}

        #endregion


        Dictionary<string, FrameworkElement> _viewsDictionary;
        Dictionary<string, ViewModel> _viewModelsDictionary;


        #region CurrentView

        //private FrameworkElement _currentView;
        //public FrameworkElement CurrentView
        //{
        //    get => _currentView;
        //    set => Set(ref _currentView, value);
        //}

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

            //WindowWidth = CurrentView_Width + 30;
            //WindowHeight = CurrentView_Height + 30;
        }

        #endregion




        public void ChangeCurrentView(string name)
        {
            if (name == null || name == "") return; // прописать вывод ошибки

            //if (!_viewsDictionary.ContainsKey(name))
            //{
            //    CreateNewView(name);
            //}

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
                    //_viewsDictionary.Add(name, new MainMenu());
                    _viewModelsDictionary.Add(name, new MainMenuViewModel(this));
                    break;
                case "field":
                    //_viewsDictionary.Add(name, new FieldView());
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
