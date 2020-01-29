using MovieStore.Core.Enum;
using MovieStore.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data.ViewModel
{
    public class ProjectVM : BaseVM
    {
        public Guid MovieId { get; set; }
        public string MovieName { get; set; }

        public Guid TranslateLanguageId { get; set; }
        public string TranslateLanguageCode { get; set; }

        public ProjectStatus Status { get; set; }
        public string StatusStr { get; set; }
        public string DueDate { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
    }
}
