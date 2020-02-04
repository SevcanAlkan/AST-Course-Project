using MovieStore.Core.Enum;
using MovieStore.Core.Validation;
using MovieStore.Data.Helper;
using MovieStore.Data.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MovieStore.Desktop.Views
{
    public partial class ProjectDetail
    {
        private void LoadCastGrid()
        {
            this.grdCastList.ItemsSource = _vm.GetCastList();
        }

        private void ConfigureCastGrid()
        {
            foreach (var column in this.grdCastList.Columns)
            {
                if (column.Header.ToString() == "Id"
                    || column.Header.ToString() == "ProjectId"
                    || column.Header.ToString() == "ProjectName"
                    || column.Header.ToString() == "Status"
                    || column.Header.ToString() == "PersonId")
                {
                    column.Visibility = Visibility.Hidden;
                }
                else if (column.Header.ToString() == "PersonName")
                {
                    column.MinWidth = 100;
                    column.DisplayIndex = 1;
                    column.Header = "Name";
                    column.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "PersonAge")
                {
                    column.MinWidth = 100;
                    column.DisplayIndex = 2;
                    column.Header = "Age";
                    column.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "StatusStr")
                {
                    column.MinWidth = 100;
                    column.DisplayIndex = 3;
                    column.Header = "Status";
                    column.Width = new DataGridLength(100, DataGridLengthUnitType.Pixel);
                }
                else if (column.Header.ToString() == "IsDeleted")
                {
                    column.MinWidth = 60;
                    column.DisplayIndex = 8;
                    column.Width = new DataGridLength(60, DataGridLengthUnitType.Pixel);
                }
            }
        }

        private void BindDataToCastFormComponents()
        {
            #region Status ComboBox 
            this.cbCastStatus.ItemsSource = EnumHelper.GetSelectList<ProjectStatus>();
            this.cbCastStatus.DisplayMemberPath = "Text";
            this.cbCastStatus.SelectedValuePath = "Value";
            #endregion

            #region Person ComboBox
            this.cbCastPerson.ItemsSource = _vm.GetPersonList();
            this.cbCastPerson.DisplayMemberPath = "Text";
            this.cbCastPerson.SelectedValuePath = "Value";
            #endregion
        }

        private async void LoadCastRec(Guid? id = null)
        {
            this._vm.CastRec = new Domain.ProjectCast();
            this.BindDataToCastFormComponents();            

            if (!id.IsNullOrEmpty())
            {
                _vm.CastRec = await _vm.GetCastById(id.Value);

                if (!_vm.CastRec.IsNull())
                {
                    var statusItem = cbCastStatus.Items.OfType<SelectListVM>().FirstOrDefault(x => x.Value == EnumHelper.GetSelectItem<ProjectStatus>(_vm.CastRec.Status).Value);
                    cbCastStatus.SelectedIndex = cbCastStatus.Items.IndexOf(statusItem);

                    var personItem = cbCastPerson.Items.OfType<SelectListGuidVM>().FirstOrDefault(x => x.Value == _vm.CastRec.PersonId);
                    cbCastPerson.SelectedIndex = cbCastPerson.Items.IndexOf(personItem);

                    txtCastEnglishText.Text = _vm.CastRec.EnglishText;
                    txtCastLocalText.Text = _vm.CastRec.LocalLanguageText;
                }
            }
            else
            {
                txtCastLocalText.Text = "";
                txtCastEnglishText.Text = "";
            }

            this.tiCastDetail.Visibility = Visibility.Visible;
            this.tiCastDetail.IsSelected = true;

            this.btnSave.IsEnabled = false;
            this.btnCancel.IsEnabled = false;
        }

        private void UnloadCastRec()
        {
            this.tiCastDetail.Visibility = Visibility.Hidden;
            this.tiCastDetail.IsSelected = false;
            this.tiCast.IsSelected = true;
            this.tcMain.SelectedIndex = 0;
            this._vm.CastRec = new Domain.ProjectCast();
            this.btnSave.IsEnabled = true;
            this.btnCancel.IsEnabled = true;
        }

        private void grdCastList_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCastGrid();
            ConfigureCastGrid();
        }

        private void btnCastAdd_Click(object sender, RoutedEventArgs e)
        {
            this.LoadCastRec();
        }

        private void btnCastEdit_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdCastList.SelectedItem;

            if (rec != null && rec is ProjectCastVM)
            {
                this.LoadCastRec((rec as ProjectCastVM).Id);
            }
        }

        private async void btnCastDelete_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdCastList.SelectedItem;

            if (rec != null && rec is ProjectCastVM)
            {
                bool result = await _vm.DeleteCast((rec as ProjectCastVM).Id);

                if (result)
                {
                    LoadCastGrid();
                    ConfigureCastGrid();
                }
                else
                {
                    MessageBox.Show("The record couldn't deleted!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnLoadTranscript_Click(object sender, RoutedEventArgs e)
        {
            var rec = this.grdCastList.SelectedItem;

            if (rec != null && rec is ProjectCastVM)
            {

            }
        }

        private async void btnCastSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.CastRec.LocalLanguageText = txtCastLocalText.Text;
            _vm.CastRec.EnglishText = txtCastEnglishText.Text;

            var personId = new Guid(cbCastPerson.SelectedValue.ToString());
            if (personId == null || personId == Guid.Empty)
                throw new Exception();

            _vm.CastRec.ProjectId = _vm.Id;
            _vm.CastRec.PersonId = personId;
            _vm.CastRec.Status = (ProjectStatus)Enum.ToObject(typeof(ProjectStatus), (cbStatus.SelectedItem as SelectListVM).Value);

            if (_vm.CastRec == null || _vm.CastRec.Id == null || _vm.CastRec.Id.IsNotValid())
            {
                await _vm.AddCast();
            }
            else
            {
                await _vm.UpdateCast();
            }

            this.UnloadCastRec();
        }

        private void btnCastCancel_Click(object sender, RoutedEventArgs e)
        {
            this.UnloadCastRec();
        }
    }
}
