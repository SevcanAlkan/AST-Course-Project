using MovieStore.Core.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain
{
    public class PersonBase : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Bio { get; set; }
        [Range(0, 150), DefaultValue(0)]
        public short? Age { get; set; }
    }

    public class Person : PersonBase
    {

        //Foreign keys...
        public virtual ICollection<MovieCast> Movies { get; set; }
        public virtual ICollection<ProjectCast> ProjectCasts { get; set; }

        public Person()
        {
            Movies = new HashSet<MovieCast>();
            ProjectCasts = new HashSet<ProjectCast>();
        }
    }
}
