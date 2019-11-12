using MovieStore.Core.EntityFramework;
using MovieStore.Core.Enum;
using MovieStore.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class ProjectCastBase : BaseEntity
    {
        [GuidValidation]
        public Guid ProjectId { get; set; }
        [GuidValidation]
        public Guid PersonId { get; set; }
        [Required]
        public string EnglishText { get; set; }
        [Required]
        public string LocalLanguageText { get; set; }
        [Required, DefaultValue(1)]
        public ProjectStatus Status { get; set; }
    }

    public class ProjectCast : ProjectCastBase
    {

        //Foreign keys...
        public virtual Project Project { get; set; }
        public virtual Person Person { get; set; }

        public ProjectCast()
        {
        }
    }
}
