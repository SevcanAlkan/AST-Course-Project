using MovieStore.Core.Enum;
using MovieStore.Core.ViewModel;
using System;

namespace MovieStore.Data.ViewModel
{
    public class ProjectCastVM : BaseVM
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }

        public Guid PersonId { get; set; }
        public string PersonName { get; set; }
        public int PersonAge { get; set; }

        public ProjectStatus Status { get; set; }
        public string StatusStr { get; set; }
    }
}
