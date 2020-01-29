using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Core.Enum;
using MovieStore.Data.SubStructure;
using MovieStore.Data.ViewModel;
using MovieStore.Domain;
using MovieStore.Core.Validation;

namespace MovieStore.Data.Service
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        private IRepository<Language> _languageRepository;

        #region Ctor

        public ProjectService(IRepository<Project> repository, IRepository<Language> languageRepository)
            : base(repository)
        {
            _languageRepository = languageRepository;
        }

        #endregion

        #region Methods                

        public List<ProjectVM> GetList(DateTime? startDate = null, DateTime? endDate = null, Guid? movieId = null, ProjectStatus? status = null, Guid? languageId = null, bool showIsDeleted = false)
        {
            var query = this.Repository.Get();

            if(!startDate.IsNullOrEmpty())
            {
                query = query.Where(a => a.DueDate > startDate).AsQueryable();
            }

            if (!endDate.IsNullOrEmpty())
            {
                query = query.Where(a => a.DueDate < endDate).AsQueryable();
            }

            if (!movieId.IsNullOrEmpty())
            {
                query = query.Where(a => a.MovieId == movieId).AsQueryable();
            }

            if (!status.IsNull() && !Validation.IsNullOrEmptyEnum<ProjectStatus>(status.Value))
            {
                query = query.Where(a => a.MovieId == movieId).AsQueryable();
            }

            if (!languageId.IsNullOrEmpty())
            {
                query = query.Where(a => a.TranslateLanguageId == languageId).AsQueryable();
            }

            
            query = query.Where(a => showIsDeleted || !a.IsDeleted).AsQueryable();            

            var result = query.ToList().Select(a => new ProjectVM()
            {
                Id = a.Id,
                IsDeleted = a.IsDeleted,
                Code = a.Code,
                Subject = a.Subject,
                DueDate = a.DueDate != null && a.DueDate != DateTime.MinValue ? a.DueDate.Value.ToString("yyyy-MM-dd hh:mm") : " - ",
                MovieName = a.Movie.Name,
                MovieId = a.MovieId,
                Status = a.Status,
                StatusStr = a.Status.ToString(),
                TranslateLanguageCode = _languageRepository.Get().Where(l => l.Id == a.TranslateLanguageId).Select(s => s.Code).FirstOrDefault(),
                TranslateLanguageId = a.TranslateLanguageId
            }).ToList();

            return result;
        }

        #endregion
    }

    public interface IProjectService : IBaseService<Project>
    {
        List<ProjectVM> GetList(DateTime? startDate = null, DateTime? endDate = null, Guid? movieId = null, ProjectStatus? status = null, Guid? languageId = null, bool showIsDeleted = false);
    }
}
