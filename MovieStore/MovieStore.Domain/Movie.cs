using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieBase : BaseEntity
    {
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Year { get; set; }
        public short Rate { get; set; }
        public int SoldAmount { get; set; }
        public double Price { get; set; }
    }

    public class Movie : MovieBase
    {

        //Foreign keys...

        public Movie()
        {

        }
    }
}
