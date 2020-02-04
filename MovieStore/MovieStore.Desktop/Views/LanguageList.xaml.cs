using MovieStore.Desktop.ViewModel;
using MovieStore.Domain;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MovieStore.Desktop.Views
{
    /// <summary>
    /// Interaction logic for LanguageList.xaml
    /// </summary>
    public partial class LanguageList : UserControl
    {
        public LanguageList()
        {
            InitializeComponent();
        }

        private LanguageListViewModel _vm
        {
            get
            {
                return (LanguageListViewModel)this.DataContext;
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
                this.grdList.ItemsSource = data.OrderBy(o => o.Name).ToList();
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
                if (column.Header.ToString() == "Id" || column.Header.ToString() == "Movies" || column.Header.ToString() == "Projects")
                {
                    column.Visibility = Visibility.Hidden;
                }
                else if (column.Header.ToString() == "Code")
                {
                    column.MinWidth = 50;
                    column.DisplayIndex = 2;
                    column.Width = new DataGridLength(50, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "Name")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 3;
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "NativeName")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 4;
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "IsDeleted")
                {
                    column.MinWidth = 60;
                    column.DisplayIndex = 5;
                    column.Width = new DataGridLength(60, DataGridLengthUnitType.Pixel);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;

            if (_window != null)
            {
                if (rec != null && rec is Language)
                {
                    _window.Id = (rec as Language).Id;
                }

                _window.DataContext = null;
                _window.LoadLanguageDetail();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.Id = Guid.Empty;
                _window.DataContext = null;
                _window.LoadLanguageDetail();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;
            if (rec != null && rec is Language)
            {
                await _vm.Delete((rec as Language).Id);
                this.Load();
                this.ConfigureGrid();
            }
        }
    }
}
