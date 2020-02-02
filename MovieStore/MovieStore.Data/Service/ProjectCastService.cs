using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Core.Enum;
using MovieStore.Data.Helper;
using MovieStore.Data.SubStructure;
using MovieStore.Data.ViewModel;
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

        public List<ProjectCastVM> GetList(Guid projectId)
        {
            return this.GetAll(a => a.ProjectId == projectId && a.IsDeleted == false).Select(s => new ProjectCastVM()
            {
                ProjectId = s.ProjectId,
                ProjectName = s.Project.Subject,
                PersonId = s.PersonId,
                PersonName = s.Person.Name,
                PersonAge = s.Person.Age ?? 0,
                Status = s.Status,
                StatusStr = EnumHelper.GetDescription<ProjectStatus>(s.Status)
            }).ToList();
        }

        #endregion
    }

    public interface IProjectCastService : IBaseService<ProjectCast>
    {
        List<ProjectCastVM> GetList(Guid projectId);
    }
}
