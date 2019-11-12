using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class MovieCastService : BaseService<MovieCast>, IMovieCastService
    {
        #region Ctor

        public MovieCastService(IRepository<MovieCast> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IMovieCastService : IBaseService<MovieCast>
    {
    }
}
