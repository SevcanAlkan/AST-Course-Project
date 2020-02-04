using MovieStore.Core.Validation;
using MovieStore.Desktop.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MovieStore.Desktop.Views
{
    /// <summary>
    /// Interaction logic for PersonDetail.xaml
    /// </summary>
    public partial class PersonDetail : UserControl
    {
        public PersonDetail()
        {
            InitializeComponent();
        }

        private PersonDetailViewModel _vm
        {
            get
            {
                return (PersonDetailViewModel)this.DataContext;
            }
        }

        private MainWindow _window
        {
            get
            {
                return Window.GetWindow(this) as MainWindow;
            }
        }

        private void LoadData()
        {
            _vm.LoadRec(_window.Id);

            if (_vm.Rec != null)
            {
                this.txtName.Text = _vm.Rec.Name;
                this.txtAge.Text = _vm.Rec.Age.ToString();
                this.txtBio.Text = _vm.Rec.Bio;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.Rec.Name = txtName.Text;
            short.TryParse(txtAge.Text, out short age);
            _vm.Rec.Age = age;
            _vm.Rec.Bio = txtBio.Text;

            if (_vm.Id == null || _vm.Id.IsNotValid())
            {
                await _vm.Add();
            }
            else
            {
                await _vm.Update();
            }

            UnLoadPage();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            UnLoadPage();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadData();
        }

        private void UnLoadPage()
        {
            _vm.Clean();

            if (_window != null)
            {
                _window.DataContext = null;
                _window.LoadPersonList();
            }
        }
    }
}
