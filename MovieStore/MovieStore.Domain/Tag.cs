using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class TagBase : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }

    public class Tag : TagBase
    {

        //Foreign keys...
        public virtual ICollection<MovieTag> Movies { get; set; }

        public Tag()
        {
            Movies = new HashSet<MovieTag>();
        }
    }
}
