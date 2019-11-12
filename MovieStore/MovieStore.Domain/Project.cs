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
    public class ProjectBase : TableEntity
    {
        [GuidValidation]
        public Guid MovieId { get; set; }
        [Required, DefaultValue(1)]
        public ProjectStatus Status { get; set; }        
        public DateTime? DueDate { get; set; }
        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(100)]
        public string Subject { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }
        [GuidValidation]
        public Guid TranslateLanguageId { get; set; }
    }

    public class Project : ProjectBase
    {

        //Foreign keys...
        public virtual Movie Movie { get; set; }
        public virtual Language TranslateLanguage { get; set; }

        public virtual ICollection<ProjectCast> Cast { get; set; }

        public Project()
        {
            Cast = new HashSet<ProjectCast>();
        }
    }
}
