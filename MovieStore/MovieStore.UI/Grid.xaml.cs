using MovieStore.Domain;
using MovieStore.UI.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MovieStore.UI
{
    /// <summary>
    /// Interaction logic for Grid.xaml
    /// </summary>
    public partial class Grid : UserControl
    {
        private List<ToolbarFilter> Filters { get; set; }

        //For test friltering
        public List<Genre> genres { get; set; }

        public Grid()
        {
            InitializeComponent();

            this.Filters = new List<ToolbarFilter>();
        }

        #region Load & Refresh

        public void Load()
        {
            loadFilters();
            loadGrid();
        }

        private void loadFilters()
        {
            this.tbFilter.Items.Clear();

            if (Filters != null && Filters.Count > 0)
            {
                this.tbFilter.Visibility = Visibility.Visible;

                ToolbarLoader.Load(ref this.tbFilter, Filters);
            }
            else
            {
                this.tbFilter.Visibility = Visibility.Collapsed;
            }
        }

        private void loadGrid()
        {
            this.genres = new List<Genre>();
            genres.Add(new Genre() { Name = "Action", Description = "Action Movies" });
            genres.Add(new Genre() { Name = "Comedy", Description = "Action Movies" });
            genres.Add(new Genre() { Name = "Romantic Comedy", Description = "Action Movies" });
            genres.Add(new Genre() { Name = "Dram", Description = "Action Movies" });
            genres.Add(new Genre() { Name = "Crime", Description = "Police" });

            this.dataGrid.ItemsSource = this.genres;
        }

        public void Refresh()
        {

        }

        #endregion

        #region Filter

        public void AddFilter(ToolbarFilter filter)
        {
            if (filter != null)
            {
                this.Filters.Add(filter);
            }
        }

        public void AddFilterRange(List<ToolbarFilter> filters)
        {
            if (filters != null)
            {
                foreach (var item in filters)
                {
                    this.AddFilter(item);
                }
            }
        }

        #endregion
    }
}
