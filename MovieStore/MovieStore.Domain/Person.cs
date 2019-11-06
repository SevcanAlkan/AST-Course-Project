using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class PersonBase : BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public short? Age { get; set; }
    }

    public class Person : PersonBase
    {

        //Foreign keys...

        public Person()
        {

        }
    }
}
