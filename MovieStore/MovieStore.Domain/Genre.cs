using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class GenreBase : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class Genre : GenreBase
    {

        //Foreign keys...

        public Genre()
        {

        }
    }
}
