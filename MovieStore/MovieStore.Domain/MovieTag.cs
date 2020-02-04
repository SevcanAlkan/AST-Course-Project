using MovieStore.Core.EntityFramework;
using MovieStore.Core.Validation;
using System;

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
