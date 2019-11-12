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
        public ObservableCollection<Item> Movies { get; set; }

        public MainWindow()
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

            var u1 = CreateMovieItem();
            var u2 = CreateMovieItem();

            grdMovies.VerticalAlignment = VerticalAlignment.Top;
            grdMovies.HorizontalAlignment = HorizontalAlignment.Left;

            grdMovies.ColumnDefinitions.Add(new ColumnDefinition());
            grdMovies.ColumnDefinitions.Add(new ColumnDefinition());
            grdMovies.ColumnDefinitions.Add(new ColumnDefinition());
            grdMovies.ColumnDefinitions.Add(new ColumnDefinition());

            grdMovies.RowDefinitions.Add(new RowDefinition());
            grdMovies.RowDefinitions.Add(new RowDefinition());
            grdMovies.RowDefinitions.Add(new RowDefinition());
            //Write an method to configure the grid. The method will take recordAmount parameter for calculate rows and columns.
            grdMovies.UpdateLayout();

            Grid.SetRow(u1, 0);
            Grid.SetRow(u2, 0);

            Grid.SetColumn(u1, 0);
            Grid.SetColumn(u2, 1);

            grdMovies.Children.Add(u1);
            grdMovies.Children.Add(u2);
            

            grdMovies.UpdateLayout();
            
        }

        private UserControl CreateMovieItem()
        {
            UserControl u1 = new UserControl();
            u1.Height = 200;
            u1.Width = 120;            
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"E:\Projects\Develop\MovieStore\MovieStore\MovieStore.Desktop\Assets\SampleCover.jpg", UriKind.RelativeOrAbsolute));
            u1.Content = img;

            return u1;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public bool Required { get; set; }
    }
}
