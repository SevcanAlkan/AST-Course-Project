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

            Bind<LoginViewModel>().ToSelf().InTransientScope();
            Bind<GenreViewModel>().ToSelf().InTransientScope();
        }
    }
}
