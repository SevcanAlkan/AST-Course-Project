using MovieStore.Desktop.ViewModel;
using MovieStore.Domain;
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
    /// Interaction logic for GenreList.xaml
    /// </summary>
    public partial class GenreList : UserControl
    {
        public GenreList()
        {
            InitializeComponent();
        }

        private GenreViewModel _vm
        {
            get
            {
                return (GenreViewModel)this.DataContext;
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
            Load();

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
            var window = Window.GetWindow(this) as MainWindow;

            if (window != null)
            {
                if (rec != null)
                {
                    window.Id = (rec as Genre).Id;
                }

                window.DataContext = null;
                window.LoadGenreDetail();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                window.Id = Guid.Empty;
                window.DataContext = null;
                window.LoadGenreDetail();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
