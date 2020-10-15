using MovieStore.Core.Validation;
using MovieStore.Data.ViewModel;
using MovieStore.Desktop.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieStore.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MovieDetail.xaml
    /// </summary>
    public partial class MovieDetail : UserControl
    {
        private MovieDetailViewModel _vm
        {
            get
            {
                return (MovieDetailViewModel)this.DataContext;
            }
        }

        private MainWindow _window
        {
            get
            {
                return Window.GetWindow(this) as MainWindow;
            }
        }

        public MovieDetail()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            _vm.LoadRec(_window.Id);
            this.BindDataToComponentts();

            if (_vm.Rec != null)
            {
                this.txtName.Text = _vm.Rec.Name;
                this.txtDescription.Text = _vm.Rec.Description;
                this.txtYear.Text = _vm.Rec.Year.ToString();
                this.txtTranslateLanguage.Text = _vm.GetLanguageName(_vm.Rec.LanguageId);

                var publisherItem = cbPublisher.Items.OfType<SelectListVM<Guid>>().FirstOrDefault(x => x.Value == _vm.Rec.PublisherId);
                cbPublisher.SelectedIndex = cbPublisher.Items.IndexOf(publisherItem);
            }
        }

        private void BindDataToComponentts()
        {
            #region Publisher ComboBox
            this.cbPublisher.ItemsSource = _vm.GetPublisherList();
            this.cbPublisher.DisplayMemberPath = "Text";
            this.cbPublisher.SelectedValuePath = "Value";
            #endregion
        }

        private void btnSelectLanguage_Click(object sender, RoutedEventArgs e)
        {
            this.lstLanguage.Visibility = Visibility.Visible;
            this.txtTranslateLanguage.IsEnabled = true;

            this.loadLanguageList();
        }

        private void lstLanguage_Selected(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item == null)
                return;

            this.lstLanguage.Visibility = Visibility.Hidden;
            this.txtTranslateLanguage.IsEnabled = false;

            var selectedValue = lstLanguage.SelectedValue;
            Guid selectedId = new Guid(selectedValue.ToString());

            if (selectedValue != null && selectedId != Guid.Empty)
            {
                var language = _vm.GetLanguage(selectedId);
                _vm.Rec.LanguageId = language.Id;
                this.txtTranslateLanguage.Text = language.Code + " " + language.Name;
            }
            else
            {
                this.txtTranslateLanguage.Text = "";
            }

            this.lstLanguage.ItemsSource = null;
        }

        private void txtTranslateLanguage_KeyDown(object sender, KeyEventArgs e)
        {
            this.loadLanguageList(txtTranslateLanguage.Text);
        }
        private void txtTranslateLanguage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                this.loadLanguageList(txtTranslateLanguage.Text);
            }
        }

        private void loadLanguageList(string searchKey = "")
        {
            this.lstLanguage.ItemsSource = null;
            this.lstLanguage.ItemsSource = _vm.GetLanguageList(searchKey);
            this.lstLanguage.DisplayMemberPath = "Name";
            this.lstLanguage.SelectedValuePath = "Id";
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.Rec.Name = txtName.Text;
            _vm.Rec.Description = txtDescription.Text;

            int.TryParse(txtYear.Text, out int yearValue);
            _vm.Rec.Year = yearValue;

            var publisherId = new Guid(cbPublisher.SelectedValue.ToString());
            if (publisherId == null || publisherId == Guid.Empty)
                throw new Exception();

            _vm.Rec.PublisherId = publisherId;

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
                _window.LoadMovieList();
            }
        }
    }
}
