using MovieStore.Desktop.DI;
using MovieStore.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Desktop
{
    public class ViewModelLocator
    {

        public LoginViewModel LoginViewModel
        {
            get { return IocKernel.Get<LoginViewModel>(); } 
        }

        public GenreViewModel GenreViewModel
        {
            get { return IocKernel.Get<GenreViewModel>(); }
        }

        public HomeViewModel HomeViewModel
        {
            get { return IocKernel.Get<HomeViewModel>(); }
        }
    }
}
