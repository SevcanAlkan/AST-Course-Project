using MovieStore.Core.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain
{
    public class GenreBase : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }

    public class Genre : GenreBase
    {

        //Foreign keys...
        public virtual ICollection<MovieGenre> Movies { get; set; }

        public Genre()
        {
            Movies = new HashSet<MovieGenre>();
        }
    }
}
