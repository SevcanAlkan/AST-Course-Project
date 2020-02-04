using MovieStore.Core.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain
{
    public class LanguageBase : BaseEntity
    {
        [Required, MaxLength(5)]
        public string Code { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string NativeName { get; set; }
    }

    public class Language : LanguageBase
    {

        //Foreign keys...
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public Language()
        {
            Movies = new HashSet<Movie>();
            Projects = new HashSet<Project>();
        }
    }
}
