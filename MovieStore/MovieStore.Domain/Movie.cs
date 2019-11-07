using MovieStore.Core.EntityFramework;
using MovieStore.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieBase : BaseEntity
    {
        [GuidValidation]
        public Guid PublisherId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        [Range(1600, 2500)]
        public int Year { get; set; }
        [Range(0, 5)]
        public short Rate { get; set; }
        [Range(0, int.MaxValue)]
        public int SoldAmount { get; set; }
        [Range(0, 100_000)]
        public double Price { get; set; }
    }

    public class Movie : MovieBase
    {

        //Foreign keys...
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<MovieCast> Cast { get; set; }
        public virtual ICollection<MovieContent> Contents { get; set; }
        public virtual ICollection<MovieGenre> Genres { get; set; }
        public virtual ICollection<MovieReview> Reviews { get; set; }
        public virtual ICollection<MovieTag> Tags { get; set; }


        public Movie()
        {
            Collections = new HashSet<Collection>();
            Cast = new HashSet<MovieCast>();
            Contents = new HashSet<MovieContent>();
            Genres = new HashSet<MovieGenre>();
            Reviews = new HashSet<MovieReview>();
            Tags = new HashSet<MovieTag>();
        }
    }
}
