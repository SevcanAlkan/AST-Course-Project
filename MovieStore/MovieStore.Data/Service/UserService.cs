using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        #region Ctor

        public UserService(IRepository<User> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IUserService : IBaseService<User>
    {
    }
}
