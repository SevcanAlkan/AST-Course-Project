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
