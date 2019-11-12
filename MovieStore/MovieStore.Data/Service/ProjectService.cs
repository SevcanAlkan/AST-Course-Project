using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        #region Ctor

        public ProjectService(IRepository<Project> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IProjectService : IBaseService<Project>
    {
    }
}
