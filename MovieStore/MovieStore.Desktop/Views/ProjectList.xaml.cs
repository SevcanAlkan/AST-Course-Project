using MovieStore.Core.Enum;
using MovieStore.Data.Helper;
using MovieStore.Data.ViewModel;
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
    /// Interaction logic for ProjectsList.xaml
    /// </summary>
    public partial class ProjectList : UserControl
    {
        public ProjectList()
        {
            InitializeComponent();
        }

        private ProjectListViewModel _vm
        {
            get
            {
                return (ProjectListViewModel)this.DataContext;
            }
        }

        private MainWindow _window
        {
            get
            {
                return Window.GetWindow(this) as MainWindow;
            }
        }

        private void Load(ProjectStatus? status = null)
        {
            var data = _vm.Get(status: status);
            if (data != null)
                this.grdList.ItemsSource = data;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Load();
            this.ConfigureGrid();
            this.LoadFilters();
        }

        private void LoadFilters()
        {
            #region Status ComboBox 
            this.cbStatus.ItemsSource = EnumHelper.GetSelectList<ProjectStatus>();
            this.cbStatus.DisplayMemberPath = "Text";
            this.cbStatus.SelectedValuePath = "Value";
            #endregion
        }

        private void FilterGrid(ProjectStatus? status = null)
        {
            this.Load(status);
            this.ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            foreach (var column in this.grdList.Columns)
            {
                if (column.Header.ToString() == "Id" 
                    || column.Header.ToString() == "Status" 
                    || column.Header.ToString() == "TranslateLanguageId" 
                    || column.Header.ToString() == "MovieId")
                {
                    column.Visibility = Visibility.Hidden;
                }
                else if (column.Header.ToString() == "Code")
                {
                    column.MinWidth = 100;
                    column.DisplayIndex = 2;
                    column.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "Subject")
                {
                    column.MinWidth = 300;
                    column.DisplayIndex = 3;
                    column.Width = new DataGridLength(300, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "DueDate")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 4;
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "StatusStr")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 5;
                    column.Header = "Status";
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "TranslateLanguageCode")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 6;
                    column.Header = "Translate Language";
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "MovieName")
                {
                    column.MinWidth = 200;
                    column.DisplayIndex = 7;
                    column.Header = "Movie";
                    column.Width = new DataGridLength(200, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "IsDeleted")
                {
                    column.MinWidth = 60;
                    column.DisplayIndex = 9;
                    column.Width = new DataGridLength(60, DataGridLengthUnitType.Pixel);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;

            if (_window != null)
            {
                if (rec != null && rec is ProjectVM)
                {
                    _window.Id = (rec as ProjectVM).Id;
                }

                _window.DataContext = null;
                _window.LoadProjectDetail();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_window != null)
            {
                _window.Id = Guid.Empty;
                _window.DataContext = null;
                _window.LoadProjectDetail();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdList.SelectedItem;
            if (rec != null && rec is ProjectVM)
            {
                await _vm.Delete((rec as ProjectVM).Id);
                this.Load();
                this.ConfigureGrid();
            }
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var status = (ProjectStatus)Enum.ToObject(typeof(ProjectStatus), (cbStatus.SelectedItem as SelectListVM).Value);

            this.FilterGrid(status);
        }
    }
}
