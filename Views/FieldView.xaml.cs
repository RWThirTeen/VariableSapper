using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VariableSapper.ViewModels;
using VariableSapper.ViewModels.Base;

namespace VariableSapper.Views
{
    /// <summary>
    /// Логика взаимодействия для FieldView.xaml
    /// </summary>
    public partial class FieldView : UserControl
    {
        public FieldView()
        {
            InitializeComponent();
        }

        FieldViewModel vm => this.DataContext as FieldViewModel;

        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            vm.OpenCellCommand.Execute(sender);
        }

        private void Button_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            vm.SetFlagCommand.Execute(sender);
        }
    }
}
