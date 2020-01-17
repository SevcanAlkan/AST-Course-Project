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

        public GenreService(IRepository<Genre> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                

        public override IList<Genre> GetAll()
        {
            var list = base.GetAll();

            if(list != null)
            {
                foreach (var item in list)
                {
                    item.Description = item.Description.Substring(0, 100) + "...";
                }
            }

            return list;
        }

        #endregion
    }

    public interface IGenreService : IBaseService<Genre>
    {
    }
}
