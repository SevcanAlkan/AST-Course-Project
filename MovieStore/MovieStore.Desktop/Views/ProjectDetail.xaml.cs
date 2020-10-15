using MovieStore.Core.Enum;
using MovieStore.Core.Validation;
using MovieStore.Data.Helper;
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
    /// Interaction logic for ProjectsDetail.xaml
    /// </summary>
    public partial class ProjectDetail : UserControl
    {
        public ProjectDetail()
        {
            InitializeComponent();
        }

        private ProjectDetailViewModel _vm
        {
            get
            {
                return (ProjectDetailViewModel)this.DataContext;
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
            this.BindDataToComponentts();

            if (_vm.Rec != null)
            {
                this.txtCode.Text = _vm.Rec.Code;
                this.txtSubject.Text = _vm.Rec.Subject;
                this.dpDueDate.SelectedDate = _vm.Rec.DueDate == DateTime.MinValue || _vm.Rec.DueDate == null ? DateTime.Now : _vm.Rec.DueDate.Value;
                this.txtTranslateLanguage.Text = _vm.GetLanguageName(_vm.Rec.TranslateLanguageId);
                this.txtNotes.Text = _vm.Rec.Notes;

                var statusItem = cbStatus.Items.OfType<SelectListVM<Int32>>().FirstOrDefault(x => x.Value == EnumHelper.GetSelectItem<ProjectStatus>(_vm.Rec.Status).Value);
                cbStatus.SelectedIndex = cbStatus.Items.IndexOf(statusItem);

                var movieItem = cbMovie.Items.OfType<SelectListVM<Guid>>().FirstOrDefault(x => x.Value == _vm.Rec.MovieId);
                cbMovie.SelectedIndex = cbMovie.Items.IndexOf(movieItem);
            }
        }

        private void BindDataToComponentts()
        {
            #region Status ComboBox
            this.cbStatus.ItemsSource = EnumHelper.GetSelectList<ProjectStatus>();
            this.cbStatus.DisplayMemberPath = "Text";
            this.cbStatus.SelectedValuePath = "Value";
            #endregion

            #region Movie ComboBox
            this.cbMovie.ItemsSource = _vm.GetMovieList();
            this.cbMovie.DisplayMemberPath = "Text";
            this.cbMovie.SelectedValuePath = "Value";
            #endregion
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.Rec.Code = txtCode.Text;
            _vm.Rec.Subject = txtSubject.Text;
            _vm.Rec.DueDate = dpDueDate.SelectedDate.Value;

            var movieId = new Guid(cbMovie.SelectedValue.ToString());
            if (movieId == null || movieId == Guid.Empty)
                throw new Exception();

            _vm.Rec.MovieId = movieId;
            _vm.Rec.Status = (ProjectStatus)Enum.ToObject(typeof(ProjectStatus), (cbStatus.SelectedItem as SelectListVM<Int32>).Value);
            _vm.Rec.Notes = txtNotes.Text;

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

        #region Language Selection

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
                _vm.Rec.TranslateLanguageId = language.Id;
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

        #endregion

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
                _window.LoadProjectList();
            }
        }
    }
}
