using MovieStore.Core.EntityFramework;
using MovieStore.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieReviewBase : BaseEntity
    {
        [Range(0, 5), DefaultValue(0)]
        public short Rate { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        [GuidValidation]
        public Guid UserId { get; set; }
        [GuidValidation]
        public Guid MovieId { get; set; }
    }

    public class MovieReview : MovieReviewBase
    {

        //Foreign keys...
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }

        public MovieReview()
        {

        }
    }
}
