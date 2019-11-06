using MovieStore.Core.EntityFramework;
using MovieStore.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Domain
{
    public class MovieContentBase : BaseEntity
    {
        public ContentType Type { get; set; }
        public string Content { get; set; } //Yotube URl || Article Url || Image Url
        public DateTime AddDate { get; set; }
    }

    public class MovieContent : MovieContentBase
    {

        //Foreign keys...

        public MovieContent()
        {

        }
    }
}
