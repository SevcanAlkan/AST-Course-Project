using MovieStore.Data.SubStructure;
using MovieStore.Data.ViewModel;
using MovieStore.Domain;
using System.Collections.Generic;
using System.Linq;

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

        #endregion
    }

    public interface IMovieService : IBaseService<Movie>
    {
        List<SelectListVM<Guid>> GetSelectList();
    }
}
