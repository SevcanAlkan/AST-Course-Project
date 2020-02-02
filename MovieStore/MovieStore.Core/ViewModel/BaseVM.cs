using System;

namespace MovieStore.Core.ViewModel
{
    public class BaseVM
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
