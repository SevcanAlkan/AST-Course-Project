﻿using MovieStore.Core.Validation;
using MovieStore.Desktop.ViewModel;
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
    /// Interaction logic for GenreDetail.xaml
    /// </summary>
    public partial class GenreDetail : UserControl
    {
        public GenreDetail()
        {
            InitializeComponent();
        }

        private GenreDetailViewModel _vm
        {
            get
            {
                return (GenreDetailViewModel)this.DataContext;
            }
        }

        private void LoadData()
        {
            var window = Window.GetWindow(this) as MainWindow;
            _vm.LoadRec(window.Id);

            if (_vm.Rec != null)
            {
                this.txtName.Text = _vm.Rec.Name;
                this.txtDescription.Text = _vm.Rec.Description;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Add validation

            _vm.Rec.Name = txtName.Text;
            _vm.Rec.Description = txtDescription.Text;

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

            var window = Window.GetWindow(this) as MainWindow;
            if (window != null)
            {
                window.DataContext = null;
                window.LoadGenreList();
            }
        }
    }
}
