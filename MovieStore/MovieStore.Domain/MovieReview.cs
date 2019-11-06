using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieReviewBase : BaseEntity
    {
        public short Rate { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
    }

    public class MovieReview : MovieReviewBase
    {

        //Foreign keys...

        public MovieReview()
        {

        }
    }
}
