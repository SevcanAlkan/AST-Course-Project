using MovieStore.Data;
using MovieStore.Data.Service;
using MovieStore.Data.SubStructure;
using MovieStore.Desktop.ViewModel;
using MovieStore.Domain;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Desktop.DI
{
    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<MovieStoreDbContext>().ToSelf().InSingletonScope();

            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InTransientScope();
            Bind(typeof(IBaseService<>)).To(typeof(BaseService<>)).InTransientScope();

            Bind<IUserService>().To<UserService>().InTransientScope().WithConstructorArgument(typeof(Type),
              x => x.Request.ParentContext.Plan.Type);
            Bind<IGenreService>().To<GenreService>().InTransientScope().WithConstructorArgument(typeof(Type),
             x => x.Request.ParentContext.Plan.Type);
            Bind<ILanguageService>().To<LanguageService>().InTransientScope().WithConstructorArgument(typeof(Type),
             x => x.Request.ParentContext.Plan.Type);
            Bind<IPersonService>().To<PersonService>().InTransientScope().WithConstructorArgument(typeof(Type),
             x => x.Request.ParentContext.Plan.Type);
            Bind<IPublisherService>().To<PublisherService>().InTransientScope().WithConstructorArgument(typeof(Type),
             x => x.Request.ParentContext.Plan.Type);
            Bind<ITagService>().To<TagService>().InTransientScope().WithConstructorArgument(typeof(Type),
             x => x.Request.ParentContext.Plan.Type);

            Bind<LoginViewModel>().ToSelf().InTransientScope();
            Bind<HomeViewModel>().ToSelf().InTransientScope();

            Bind<GenreListViewModel>().ToSelf().InTransientScope();
            Bind<GenreDetailViewModel>().ToSelf().InTransientScope();

            Bind<LanguageListViewModel>().ToSelf().InTransientScope();
            Bind<LanguageDetailViewModel>().ToSelf().InTransientScope();

            Bind<PersonListViewModel>().ToSelf().InTransientScope();
            Bind<PersonDetailViewModel>().ToSelf().InTransientScope();

            Bind<PublisherListViewModel>().ToSelf().InTransientScope();
            Bind<PublisherDetailViewModel>().ToSelf().InTransientScope();

            Bind<TagListViewModel>().ToSelf().InTransientScope();
            Bind<TagDetailViewModel>().ToSelf().InTransientScope();

            Bind<UserListViewModel>().ToSelf().InTransientScope();
            Bind<UserDetailViewModel>().ToSelf().InTransientScope();

        }
    }
}
