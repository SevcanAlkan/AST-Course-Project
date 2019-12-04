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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieStore.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User CurrentUser { get; set; }
    
        private ViewModelLocator _viewModelLocator;

        public MainWindow()
        {
            _viewModelLocator = new ViewModelLocator();
           
            InitializeComponent();
        }

        public void UpdateUser()
        {
            //if(CurrentUser != null)
            //{
            //    this.txtCurrentUser.Text = this.CurrentUser.DisplayName;
            //    this.btnLogout.IsEnabled = true;
            //}
            //else
            //{
            //    this.txtCurrentUser.Text = "";
            //    this.btnLogout.IsEnabled = false;
            //}
        }

        private void Close()
        {
            //Do Someting.


            //Then close the app.
            Application.Current.Shutdown();
        }

        private void Logout()
        {
            this.CurrentUser = null;
            this.UpdateUser();
            this.DataContext = _viewModelLocator.LoginViewModel;
        }
        
        #region Generic Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                DataContext = _viewModelLocator.LoginViewModel;
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
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Logout();
        }

        #endregion

        #region Nav Bar Click Events

        private void liHome_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void liProject_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void liMovie_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void liUser_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void liLanguage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void liTag_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void liPublisher_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void liPerson_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void liGenre_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = _viewModelLocator.GenreViewModel;
        }

        #endregion


    }


}
