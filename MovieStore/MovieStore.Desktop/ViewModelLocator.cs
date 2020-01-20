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

        public HomeViewModel HomeViewModel
        {
            get { return IocKernel.Get<HomeViewModel>(); }
        }

        #region Support Pages

        public GenreListViewModel GenreListViewModel
        {
            get { return IocKernel.Get<GenreListViewModel>(); }
        }
        public GenreDetailViewModel GenreDetailViewModel
        {
            get { return IocKernel.Get<GenreDetailViewModel>(); }
        }

        public LanguageListViewModel LanguageListViewModel
        {
            get { return IocKernel.Get<LanguageListViewModel>(); }
        }
        public LanguageDetailViewModel LanguageDetailViewModel
        {
            get { return IocKernel.Get<LanguageDetailViewModel>(); }
        }

        public PersonListViewModel PersonListViewModel
        {
            get { return IocKernel.Get<PersonListViewModel>(); }
        }
        public PersonDetailViewModel PersonDetailViewModel
        {
            get { return IocKernel.Get<PersonDetailViewModel>(); }
        }

        public PublisherListViewModel PublisherListViewModel
        {
            get { return IocKernel.Get<PublisherListViewModel>(); }
        }
        public PublisherDetailViewModel PublisherDetailViewModel
        {
            get { return IocKernel.Get<PublisherDetailViewModel>(); }
        }

        public TagListViewModel TagListViewModel
        {
            get { return IocKernel.Get<TagListViewModel>(); }
        }
        public TagDetailViewModel TagDetailViewModel
        {
            get { return IocKernel.Get<TagDetailViewModel>(); }
        }

        public UserListViewModel UserListViewModel
        {
            get { return IocKernel.Get<UserListViewModel>(); }
        }
        public UserDetailViewModel UserDetailViewModel
        {
            get { return IocKernel.Get<UserDetailViewModel>(); }
        }

        #endregion
    }
}
