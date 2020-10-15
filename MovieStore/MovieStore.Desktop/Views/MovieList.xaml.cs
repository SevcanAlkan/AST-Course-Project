using MovieStore.Data.ViewModel;
using MovieStore.Desktop.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MovieStore.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MovieList.xaml
    /// </summary>
    public partial class MovieList : UserControl
    {

        private MovieListViewModel _vm
        {
            get
            {
                return (MovieListViewModel)this.DataContext;
            }
        }

        private MainWindow _window
        {
            get
            {
                return Window.GetWindow(this) as MainWindow;
            }
        }

        public MovieList()
        {
            InitializeComponent();
        }

        private void Load()
        {
            var data = _vm.Get();
            if (data != null)
                this.grdList.ItemsSource = data;
        }

        private void ConfigureGrid()
        {
            foreach (var column in this.grdList.Columns)
            {
                if (column.Header.ToString() == "Id"
                    || column.Header.ToString() == "LanguageId"
                    || column.Header.ToString() == "PublisherId")
                {
                    column.Visibility = Visibility.Hidden;
                }
                else if (column.Header.ToString() == "Name")
                {
                    column.MinWidth = 100;
                    column.DisplayIndex = 2;
                    column.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "LanguageCode")
                {
                    column.MinWidth = 50;
                    column.DisplayIndex = 3;
                    column.Header = "Language";
                    column.Width = new DataGridLength(50, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "Year")
                {
                    column.MinWidth = 50;
                    column.DisplayIndex = 4;
                    column.Width = new DataGridLength(50, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "PublisherName")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 5;
                    column.Header = "Publisher Name";
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "IsDeleted")
                {
                    column.MinWidth = 60;
                    column.DisplayIndex = 6;
                    column.Width = new DataGridLength(60, DataGridLengthUnitType.Pixel);
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Load();
            this.ConfigureGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.Id = Guid.Empty;
                _window.DataContext = null;
                _window.LoadMovieDetail();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;

            if (_window != null)
            {
                if (rec != null && rec is MovieVM)
                {
                    _window.Id = (rec as MovieVM).Id;
                }

                _window.DataContext = null;
                _window.LoadMovieDetail();
            }
        }


        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;
            if (rec != null && rec is MovieVM)
            {
                await _vm.Delete((rec as MovieVM).Id);
                this.Load();
                this.ConfigureGrid();
            }
        }
    }
}
