using MovieStore.Core.EntityFramework;
using MovieStore.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieCastBase : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Guid PersonId { get; set; }

        public CastRole Role { get; set; }
    }

    public class MovieCast : MovieCastBase
    {

        //Foreign keys...

        public MovieCast()
        {

        }
    }
}
