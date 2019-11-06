using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class CollectionBase : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public DateTime AddDate { get; set; }
        public double BoughtPrice { get; set; }
    }

    public class Collection : CollectionBase
    {

        //Foreign keys...

        public Collection()
        {

        }
    }
}
