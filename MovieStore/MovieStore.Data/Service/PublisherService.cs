using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class PublisherService : BaseService<Publisher>, IPublisherService
    {
        #region Ctor

        public PublisherService(IRepository<Publisher> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IPublisherService : IBaseService<Publisher>
    {
    }
}
