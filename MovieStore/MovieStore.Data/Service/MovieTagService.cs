﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class MovieTagService : BaseService<MovieTag>, IMovieTagService
    {
        #region Ctor

        public MovieTagService(IRepository<MovieTag> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IMovieTagService : IBaseService<MovieTag>
    {
    }
}