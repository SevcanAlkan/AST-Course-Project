using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class MovieGenreService : BaseService<MovieGenre>, IMovieGenreService
    {
        #region Ctor

        public MovieGenreService(IRepository<MovieGenre> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IMovieGenreService : IBaseService<MovieGenre>
    {
    }
}
