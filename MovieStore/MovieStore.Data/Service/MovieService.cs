using MovieStore.Data.SubStructure;
using MovieStore.Data.ViewModel;
using MovieStore.Domain;
using System.Collections.Generic;
using System.Linq;
using System;
using MovieStore.Core.Validation;

namespace MovieStore.Data.Service
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        #region Ctor

        public MovieService(IRepository<Movie> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods

        public List<SelectListVM<Guid>> GetSelectList()
        {
            return this.AsQueryable()
                .Where(a => a.IsDeleted == false)
                .Select(s => new SelectListVM<Guid>()
                {
                    Value = s.Id,
                    Text = s.Name
                }).ToList();
        }

        public List<MovieVM> GetList(int? year = null, Guid? languageId = null, Guid? publisherId = null, bool showIsDeleted = false)
        {
            var query = this.Repository.Get();

            if (!year.IsNull())
            {
                query = query.Where(a => a.Year == year).AsQueryable();
            }

            if (!publisherId.IsNullOrEmpty())
            {
                query = query.Where(a => a.PublisherId == publisherId).AsQueryable();
            }

            if (!languageId.IsNullOrEmpty())
            {
                query = query.Where(a => a.LanguageId == languageId).AsQueryable();
            }

            query = query.Where(a => showIsDeleted || !a.IsDeleted).AsQueryable();

            var result = query.ToList().Select(a => new MovieVM()
            {
                Id = a.Id,
                IsDeleted = a.IsDeleted,
                Name = a.Name,
                LanguageId = a.LanguageId,
                LanguageCode = a.Language != null ? a.Language.Code : "",
                PublisherId = a.PublisherId,
                PublisherName = a.Publisher != null ? a.Publisher.Name : "",
                Year = a.Year
            }).ToList();

            return result;
        }

        #endregion
    }

    public interface IMovieService : IBaseService<Movie>
    {
        List<SelectListVM<Guid>> GetSelectList();
        List<MovieVM> GetList(int? year = null, Guid? languageId = null, Guid? publisherId = null, bool showIsDeleted = false);
    }
}
