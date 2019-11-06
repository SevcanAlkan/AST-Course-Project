using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieGenreBase : BaseEntity
    {
        public Guid GenreId { get; set; }
        public Guid MovieId { get; set; }
    }

    public class MovieGenre : MovieGenreBase
    {

        //Foreign keys...

        public MovieGenre()
        {

        }
    }
}
