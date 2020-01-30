using MovieStore.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data.ViewModel
{
    public class ProjectCastVM
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
