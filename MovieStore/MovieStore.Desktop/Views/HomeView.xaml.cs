using MovieStore.Desktop.ViewModel;
using System.Windows.Controls;

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
