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
            if(CurrentUser != null)
            {
                this.txtCurrentUser.Text = this.CurrentUser.DisplayName;
                this.btnLogout.IsEnabled = true;
            }
            else
            {
                this.txtCurrentUser.Text = "";
                this.btnLogout.IsEnabled = false;
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser = null;
            this.UpdateUser();
            DataContext = _viewModelLocator.LoginViewModel;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                DataContext = _viewModelLocator.LoginViewModel;
            }
        }

        private void btnGenre_Click(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModelLocator.GenreViewModel;
        }
    }


}
