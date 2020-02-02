using System;

namespace MovieStore.Core
{
    public class ModelCopierAttribute : Attribute
    {
        public bool DontCopy { get; set; }
    }
}
