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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private LoginViewModel _vm
        {
            get
            {
                return (LoginViewModel)this.DataContext;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtUserName == null || this.txtUserName.Text == "" || this.txtPasword == null || this.txtPasword.Text == "")
            {
                MessageBox.Show("You must enter Username and Password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string userName = this.txtUserName.Text.Trim();
            string password = this.txtPasword.Text.Trim();

            var result = _vm.Login(userName, password);

            if (result == null)
            {
                MessageBox.Show("Username or Password is incorrect!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                window.CurrentUser = result;
                window.UpdateUser();
                window.DataContext = null;
            }
        }
    }
}
