using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class ProjectCastService : BaseService<ProjectCast>, IProjectCastService
    {
        #region Ctor

        public ProjectCastService(IRepository<ProjectCast> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IProjectCastService : IBaseService<ProjectCast>
    {
    }
}
