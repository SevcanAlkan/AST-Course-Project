using System;

namespace MovieStore.Data.ViewModel
{
    public class SelectListVM<T>
    {
        public T Value { get; set; }
        public string Text { get; set; }
    }
}
