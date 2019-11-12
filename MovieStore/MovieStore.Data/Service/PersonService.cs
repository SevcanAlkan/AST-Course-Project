﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        #region Ctor

        public PersonService(IRepository<Person> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IPersonService : IBaseService<Person>
    {
    }
}