using MovieStore.Core.Validation;
using MovieStore.Data;
using MovieStore.Data.Service;
using MovieStore.Data.SubStructure;
using MovieStore.Desktop.ViewModel;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieStore.Core.Validation;
using MovieStore.Desktop.Helper;
using MovieStore.Desktop.DI;

namespace MovieStore.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private new readonly string Title = "Moview Dubbing Studio Manager";

        private User _currentUser;
        private User CurrentUser
        {
            get
            {
                if (this._currentUser == null)
                {
                    this._currentUser = new User();
                }

                return this._currentUser;
            }
            set
            {
                if (value != null)
                {
                    this._currentUser = value;
                }
            }
        }

        public Guid Id { get; set; }

        private ViewModelLocator _viewModelLocator;

        public MainWindow()
        {
            _viewModelLocator = new ViewModelLocator();

            InitializeComponent();
        }

        public void Login(User user)
        {
            if (user != null && !user.Id.IsNotValid())
            {
                this.CurrentUser = user;
                UserInfo.UserId = user.Id;
                DataContext = _viewModelLocator.HomeViewModel;
                this.SetTitle("Home");
            }

            if (!CurrentUser.Id.IsNotValid())
            {
                this.txtUserName.Text = this.CurrentUser.DisplayName;
                this.btnLogout.IsEnabled = true;
                this.btnSettings.IsEnabled = true;

                this.btnOpenMenu.IsEnabled = true;
                this.liNavbar.IsEnabled = true;
            }
            else
            {
                this.Logout();
            }
        }

        private void Logout()
        {
            this.CurrentUser = new User();
            UserInfo.UserId = Guid.Empty;
            this.DataContext = _viewModelLocator.LoginViewModel;
            this.windowContent.Focus();

            this.SetTitle();

            this.txtUserName.Text = "";
            this.btnLogout.IsEnabled = false;
            this.btnSettings.IsEnabled = false;

            this.btnOpenMenu.IsEnabled = false;
            this.liNavbar.IsEnabled = false;
        }

        private void CloseApp()
        {
            //Do Someting.


            //Then close the app.
            Application.Current.Shutdown();
        }

        private void SetTitle(string additionalText = "")
        {
            this.tbWindowTitle.Text = additionalText != string.Empty ? this.Title + " - " + additionalText : this.Title;
        }

        #region Generic Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.Id.IsNotValid())
            {
                this.Logout();
            }
            else
            {
                DataContext = _viewModelLocator.HomeViewModel;
            }
        }

        private void grdTopBar_Loaded(object sender, RoutedEventArgs e)
        {
            this.grdTopBar.MouseDown += delegate { DragMove(); };
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            this.btnOpenMenu.Visibility = Visibility.Visible;
            this.btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            this.btnCloseMenu.Visibility = Visibility.Visible;
            this.btnOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.CloseApp();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Logout();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.grdMenu.Width > 100)
            {
                //https://joshsmithonwpf.wordpress.com/2007/03/09/how-to-programmatically-click-a-button/
                ButtonAutomationPeer peer = new ButtonAutomationPeer(this.btnCloseMenu);
                IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
            }
        }

        #endregion

        #region Nav Bar Click Events

        private void liHome_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.HomeViewModel;
            this.SetTitle("Home");
        }

        private void liProject_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = null;
            this.SetTitle("Project");
        }

        private void liMovie_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = null;
            this.SetTitle("Movie");
        }

        private void liUser_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.UserListViewModel;
            this.SetTitle("User");
        }

        private void liLanguage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.LanguageListViewModel;
            this.SetTitle("Language");
        }

        private void liTag_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.TagListViewModel;
            this.SetTitle("Tag");
        }

        private void liPublisher_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.PublisherListViewModel;
            this.SetTitle("Publisher");
        }

        private void liPerson_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.PersonListViewModel;
            this.SetTitle("Person");
        }

        private void liGenre_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.GenreListViewModel;
            this.SetTitle("Genre");
        }


        #endregion

        #region Screen Switch Functions

        public void LoadGenreDetail()
        {
            DataContext = _viewModelLocator.GenreDetailViewModel;
        }
        public void LoadGenreList()
        {
            DataContext = _viewModelLocator.GenreListViewModel;
        }

        public void LoadLanguageDetail()
        {
            DataContext = _viewModelLocator.LanguageDetailViewModel;
        }
        public void LoadLanguageList()
        {
            DataContext = _viewModelLocator.LanguageListViewModel;
        }

        public void LoadPersonDetail()
        {
            DataContext = _viewModelLocator.PersonDetailViewModel;
        }
        public void LoadPersonList()
        {
            DataContext = _viewModelLocator.PersonListViewModel;
        }

        public void LoadPublisherDetail()
        {
            DataContext = _viewModelLocator.PublisherDetailViewModel;
        }
        public void LoadPublisherList()
        {
            DataContext = _viewModelLocator.PublisherListViewModel;
        }

        public void LoadTagDetail()
        {
            DataContext = _viewModelLocator.TagDetailViewModel;
        }
        public void LoadTagList()
        {
            DataContext = _viewModelLocator.TagListViewModel;
        }

        public void LoadUserDetail()
        {
            DataContext = _viewModelLocator.UserDetailViewModel;
        }
        public void LoadUserList()
        {
            DataContext = _viewModelLocator.UserListViewModel;
        }

        #endregion
    }


}
