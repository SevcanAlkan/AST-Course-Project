using MovieStore.Core.Enum;
using MovieStore.Core.Validation;
using MovieStore.Data.Helper;
using MovieStore.Data.SubStructure;
using MovieStore.Data.ViewModel;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Data.Service
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        private IRepository<Language> _languageRepository;
        private IRepository<Movie> _movieRepository;

        #region Ctor

        public ProjectService(IRepository<Project> repository, IRepository<Language> languageRepository, IRepository<Movie> movieRepository)
            : base(repository)
        {
            _languageRepository = languageRepository;
            _movieRepository = movieRepository;
        }

        #endregion

        #region Methods                

        public List<ProjectVM> GetList(DateTime? startDate = null, DateTime? endDate = null, Guid? movieId = null, ProjectStatus? status = null, Guid? languageId = null, bool showIsDeleted = false)
        {
            var query = this.Repository.Get();

            if (!startDate.IsNullOrEmpty())
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
                query = query.Where(a => a.Status == status).AsQueryable();
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
                MovieName = _movieRepository.Query().Where(m => m.Id == a.MovieId).Select(s => s.Name).FirstOrDefault(),
                MovieId = a.MovieId,
                Status = a.Status,
                StatusStr = EnumHelper.GetDescription<ProjectStatus>(a.Status),
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
