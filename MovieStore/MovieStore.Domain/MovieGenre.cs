using MovieStore.Core.EntityFramework;
using MovieStore.Core.Validation;
using System;

namespace MovieStore.Domain
{
    public class MovieGenreBase : BaseEntity
    {
        [GuidValidation]
        public Guid GenreId { get; set; }
        [GuidValidation]
        public Guid MovieId { get; set; }
    }

    public class MovieGenre : MovieGenreBase
    {

        //Foreign keys...
        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }

        public MovieGenre()
        {

        }
    }
}
