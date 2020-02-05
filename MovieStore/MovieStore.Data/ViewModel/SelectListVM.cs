using System;

namespace MovieStore.Data.ViewModel
{
    public class SelectListVM<T>  where T: String, Guid, Int32 
    {
        public T Value { get; set; }
        public string Text { get; set; }
    }
}
