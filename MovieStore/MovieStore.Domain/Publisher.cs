using MovieStore.Core.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain
{
    public class PublisherBase : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }

    public class Publisher : PublisherBase
    {

        //Foreign keys...
        public virtual ICollection<Movie> Movies { get; set; }

        public Publisher()
        {
            Movies = new HashSet<Movie>();
        }
    }
}
