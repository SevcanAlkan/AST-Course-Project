using MovieStore.Desktop.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;

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

            this.txtUserName.Focus();

            //REMOWE
            this.txtUserName.Text = "test";
            this.txtPasword.Password = "test";
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
            if (this.txtUserName == null || this.txtUserName.Text == "" || this.txtPasword == null || !this.txtPasword.Password.Any())
            {
                MessageBox.Show("You must enter Username and Password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string userName = this.txtUserName.Text.Trim();
            string password = this.txtPasword.Password.ToString().Trim();

            var result = _vm.Login(userName, password);

            if (result == null)
            {
                MessageBox.Show("Username or Password is incorrect!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                window.Login(result);
            }
        }

        private void userPageGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonAutomationPeer peer = new ButtonAutomationPeer(this.btnLogin);
                IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
            }
        }
    }
}
