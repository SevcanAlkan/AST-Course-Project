using MovieStore.Core.EntityFramework;
using MovieStore.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieTagBase : BaseEntity
    {
        [GuidValidation]
        public Guid TagId { get; set; }
        [GuidValidation]
        public Guid MovieId { get; set; }
    }

    public class MovieTag : MovieTagBase
    {

        //Foreign keys...
        public virtual Tag Tag { get; set; }
        public virtual Movie Movie { get; set; }

        public MovieTag()
        {

        }
    }
}
