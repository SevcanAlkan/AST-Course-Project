using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class TagService : BaseService<Tag>, ITagService
    {
        #region Ctor

        public TagService(IRepository<Tag> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface ITagService : IBaseService<Tag>
    {
    }
}
