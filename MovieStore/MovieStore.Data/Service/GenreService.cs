﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        #region Ctor

        public GenreService(UnitOfWork _uow)
            : base(_uow)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IGenreService : IBaseService<Genre>
    {
    }
}
