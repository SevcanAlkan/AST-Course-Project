using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class GenreBase : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
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
