using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieTagBase : BaseEntity
    {
        public Guid TagId { get; set; }
        public Guid MovieId { get; set; }
    }

    public class MovieTag : MovieTagBase
    {

        //Foreign keys...

        public MovieTag()
        {

        }
    }
}
