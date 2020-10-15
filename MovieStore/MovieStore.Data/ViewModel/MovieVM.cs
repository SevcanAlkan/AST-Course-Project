using MovieStore.Core.ViewModel;
using System;

namespace MovieStore.Data.ViewModel
{
    public class MovieVM : BaseVM
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Name { get; set; }

        public int Year { get; set; }
        public Guid LanguageId { get; set; }
        public string LanguageCode { get; set; }
    }
}
