using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.ViewModel
{
    public class BaseVM
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
