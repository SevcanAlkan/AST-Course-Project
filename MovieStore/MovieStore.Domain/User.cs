using MovieStore.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class UserBase : BaseEntity
    {
        [Required, MaxLength(20)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string DisplayName { get; set; }
        [Required, MaxLength(50)]
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
