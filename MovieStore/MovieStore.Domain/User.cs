using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class UserBase : BaseEntity
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
    }

    public class User : UserBase
    {

        //Foreign keys...

        public User()
        {

        }
    }
}
