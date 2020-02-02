using MovieStore.Core.EntityFramework;
using MovieStore.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain
{
    public class MovieBase : TableEntity
    {
        [GuidValidation]
        public Guid PublisherId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        [Range(1600, 2500)]
        public int Year { get; set; }
        [GuidValidation]
        public Guid LanguageId { get; set; }
    }

    public class Movie : MovieBase
    {

        //Foreign keys...
        public virtual Publisher Publisher { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<MovieCast> Cast { get; set; }
        public virtual ICollection<MovieGenre> Genres { get; set; }
        public virtual ICollection<MovieTag> Tags { get; set; }


        public Movie()
        {
            Projects = new HashSet<Project>();
            Cast = new HashSet<MovieCast>();
            Genres = new HashSet<MovieGenre>();
            Tags = new HashSet<MovieTag>();
        }
    }
}
