using MovieStore.UI.Model;
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

namespace MovieStore.UI
{
    /// <summary>
    /// Interaction logic for Grid.xaml
    /// </summary>
    public partial class Grid : UserControl
    {
        private List<ToolbarFilter> Filters { get; set; }

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

            if(Filters != null && Filters.Count > 0)
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
