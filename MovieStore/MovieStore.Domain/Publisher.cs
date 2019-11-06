using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class PublisherBase : BaseEntity
    {
        public string Name { get; set; }
    }

    public class Publisher : PublisherBase
    {

        //Foreign keys...

        public Publisher()
        {

        }
    }
}
