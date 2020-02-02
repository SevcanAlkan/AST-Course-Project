using MovieStore.Data.SubStructure;
using MovieStore.Domain;

namespace MovieStore.Data.Service
{
    public class LanguageService : BaseService<Language>, ILanguageService
    {
        #region Ctor

        public LanguageService(IRepository<Language> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods                


        #endregion
    }

    public interface ILanguageService : IBaseService<Language>
    {
    }
}
