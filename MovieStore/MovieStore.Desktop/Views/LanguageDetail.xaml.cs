using MovieStore.Core.Validation;
using MovieStore.Desktop.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MovieStore.Desktop.Views
{
    /// <summary>
    /// Interaction logic for LanguageDetail.xaml
    /// </summary>
    public partial class LanguageDetail : UserControl
    {
        public LanguageDetail()
        {
            InitializeComponent();
        }

        private LanguageDetailViewModel _vm
        {
            get
            {
                return (LanguageDetailViewModel)this.DataContext;
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
                this.txtCode.Text = _vm.Rec.Code;
                this.txtName.Text = _vm.Rec.Name;
                this.txtNativeName.Text = _vm.Rec.NativeName;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.Rec.Code = txtCode.Text;
            _vm.Rec.Name = txtName.Text;
            _vm.Rec.NativeName = txtName.Text;

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
                _window.LoadLanguageList();
            }
        }
    }
}
