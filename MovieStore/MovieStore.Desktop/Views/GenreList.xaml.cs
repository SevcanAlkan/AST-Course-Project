using MovieStore.Desktop.ViewModel;
using MovieStore.Domain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MovieStore.Desktop.Views
{
    /// <summary>
    /// Interaction logic for GenreList.xaml
    /// </summary>
    public partial class GenreList : UserControl
    {
        public GenreList()
        {
            InitializeComponent();
        }

        private GenreListViewModel _vm
        {
            get
            {
                return (GenreListViewModel)this.DataContext;
            }
        }

        private MainWindow _window
        {
            get
            {
                return Window.GetWindow(this) as MainWindow;
            }
        }

        private void Load()
        {
            var data = _vm.Get();
            if (data != null)
                this.grdList.ItemsSource = data;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Load();
            this.ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            foreach (var column in this.grdList.Columns)
            {
                if (column.Header.ToString() == "Id")
                {
                    column.Visibility = Visibility.Hidden;
                }
                else if (column.Header.ToString() == "Name")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 2;
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "Description")
                {
                    column.MinWidth = 500;
                    column.DisplayIndex = 3;
                    column.Width = new DataGridLength(740, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "Movies")
                {
                    column.Visibility = Visibility.Hidden;
                }
                else if (column.Header.ToString() == "IsDeleted")
                {
                    column.MinWidth = 60;
                    column.DisplayIndex = 4;
                    column.Width = new DataGridLength(60, DataGridLengthUnitType.Pixel);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;

            if (_window != null)
            {
                if (rec != null && rec is Genre)
                {
                    _window.Id = (rec as Genre).Id;
                }

                _window.DataContext = null;
                _window.LoadGenreDetail();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.Id = Guid.Empty;
                _window.DataContext = null;
                _window.LoadGenreDetail();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;
            if (rec != null && rec is Genre)
            {
                await _vm.Delete((rec as Genre).Id);
                this.Load();
                this.ConfigureGrid();
            }
        }
    }
}
