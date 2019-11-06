using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class TagBase : BaseEntity
    {
        public string Name { get; set; }
    }

    public class Tag : TagBase
    {

        //Foreign keys...

        public Tag()
        {

        }
    }
}
