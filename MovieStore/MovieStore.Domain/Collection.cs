using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain
{
    public class CollectionBase : BaseEntity
    {
        [GuidValidation]
        public Guid UserId { get; set; }
        [GuidValidation]
        public Guid MovieId { get; set; }
        public DateTime AddDate { get; set; }
        [Range(0, double.MaxValue)]
        public double BoughtPrice { get; set; }
    }

    public class Collection : CollectionBase
    {

        //Foreign keys...
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
        public Collection()
        {

        }
    }
}
