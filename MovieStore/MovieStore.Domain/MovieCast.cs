using MovieStore.Core.EntityFramework;
using MovieStore.Core.Enum;
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
    public class MovieCastBase : BaseEntity
    {
        [GuidValidation]
        public Guid MovieId { get; set; }
        [GuidValidation]
        public Guid PersonId { get; set; }
        [Required, DefaultValue(CastRole.Cast)]
        public CastRole Role { get; set; }
    }

    public class MovieCast : MovieCastBase
    {

        //Foreign keys...
        public virtual Movie Movie { get; set; }
        public virtual Person Person { get; set; }

        public MovieCast()
        {

        }
    }
}
