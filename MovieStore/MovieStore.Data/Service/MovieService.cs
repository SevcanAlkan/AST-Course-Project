﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        #region Ctor

        public MovieService(UnitOfWork _uow)
            : base(_uow)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IMovieService : IBaseService<Movie>
    {
    }
}
