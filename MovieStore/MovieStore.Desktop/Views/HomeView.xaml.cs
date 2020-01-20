using MovieStore.Desktop.ViewModel;
using MovieStore.UI.Helper;
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

            grdMain.AddFilter(FilterHelper.New("serchBox", 1, UI.Enums.FilterTypeEnum.TextBox, "Search"));
            grdMain.AddFilter(FilterHelper.New("SearchByName", 1, UI.Enums.FilterTypeEnum.TextBox, "Search By Name"));

            grdMain.Load();
        }

        private HomeViewModel _vm
        {
            get
            {
                return (HomeViewModel)this.DataContext;
            }
        }


    }   
}
