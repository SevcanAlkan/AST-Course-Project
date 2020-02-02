using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core
{
    public class ModelCopierAttribute : Attribute
    {
        public bool DontCopy { get; set; }
    }
}
