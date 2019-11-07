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
    public class MovieContentBase : BaseEntity
    {
        [Required, DefaultValue(ContentType.Undefined)]
        public ContentType Type { get; set; }
        [Required, MaxLength(1000)]
        public string Content { get; set; } //Yotube URl || Article Url || Image Url
        public DateTime AddDate { get; set; }
        [GuidValidation]
        public Guid MovieId { get; set; }
    }

    public class MovieContent : MovieContentBase
    {

        //Foreign keys...
        public virtual Movie Movie { get; set; }

        public MovieContent()
        {

        }
    }
}
