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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            LoadCollection();
        }

        private void LoadCollection()
        {
            //Movies = new ObservableCollection<Item>();
            //Movies.Add(new Item() { Name = "Username", Length = 100, Required = true });
            //Movies.Add(new Item() { Name = "Password", Length = 80, Required = true });
            //Movies.Add(new Item() { Name = "City", Length = 100, Required = false });
            //Movies.Add(new Item() { Name = "State", Length = 40, Required = false });
            //Movies.Add(new Item() { Name = "Zipcode", Length = 60, Required = false });

            //var u1 = CreateMovieItem();
            //var u2 = CreateMovieItem();

            //grdMovies.VerticalAlignment = VerticalAlignment.Top;
            //grdMovies.HorizontalAlignment = HorizontalAlignment.Left;

            //grdMovies.ColumnDefinitions.Add(new ColumnDefinition());
            //grdMovies.ColumnDefinitions.Add(new ColumnDefinition());
            //grdMovies.ColumnDefinitions.Add(new ColumnDefinition());
            //grdMovies.ColumnDefinitions.Add(new ColumnDefinition());

            //grdMovies.RowDefinitions.Add(new RowDefinition());
            //grdMovies.RowDefinitions.Add(new RowDefinition());
            //grdMovies.RowDefinitions.Add(new RowDefinition());
            ////Write an method to configure the grid. The method will take recordAmount parameter for calculate rows and columns.
            //grdMovies.UpdateLayout();

            //Grid.SetRow(u1, 0);
            //Grid.SetRow(u2, 0);

            //Grid.SetColumn(u1, 0);
            //Grid.SetColumn(u2, 1);

            //grdMovies.Children.Add(u1);
            //grdMovies.Children.Add(u2);


            //grdMovies.UpdateLayout();

        }
    }   
}
