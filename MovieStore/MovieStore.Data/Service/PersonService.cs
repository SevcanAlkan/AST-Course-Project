using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        #region Ctor

        public PersonService(IRepository<Person> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface IPersonService : IBaseService<Person>
    {
    }
}
