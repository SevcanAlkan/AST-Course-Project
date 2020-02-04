using System;

namespace MovieStore.Data.ViewModel
{
    public class SelectListVM
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

    public class SelectListGuidVM
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
    }
}
