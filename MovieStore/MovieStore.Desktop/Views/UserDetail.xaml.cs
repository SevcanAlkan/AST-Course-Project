using MovieStore.Core.Validation;
using MovieStore.Desktop.ViewModel;
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

namespace MovieStore.Desktop.Views
{
    /// <summary>
    /// Interaction logic for UserDetail.xaml
    /// </summary>
    public partial class UserDetail : UserControl
    {
        public UserDetail()
        {
            InitializeComponent();
        }

        private UserDetailViewModel _vm
        {
            get
            {
                return (UserDetailViewModel)this.DataContext;
            }
        }

        private MainWindow _window
        {
            get
            {
                return Window.GetWindow(this) as MainWindow;
            }
        }

        private void LoadData()
        {
            _vm.LoadRec(_window.Id);

            if (_vm.Rec != null)
            {
                this.txtUsername.Text = _vm.Rec.UserName;
                this.txtDisplayName.Text = _vm.Rec.DisplayName;
                this.txtPassword.Text = _vm.Rec.Password;
                this.txtConfirmPassword.Text = _vm.Rec.Password;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.Rec.UserName = txtUsername.Text;
            _vm.Rec.DisplayName = txtDisplayName.Text;
            _vm.Rec.Password = txtPassword.Text;

            if (_vm.Id == null || _vm.Id.IsNotValid())
            {
                await _vm.Add();
            }
            else
            {
                await _vm.Update();
            }

            UnLoadPage();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            UnLoadPage();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadData();
        }

        private void UnLoadPage()
        {
            _vm.Clean();

            if (_window != null)
            {
                _window.DataContext = null;
                _window.LoadUserList();
            }
        }
    }
}
