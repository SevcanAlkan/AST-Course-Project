using MovieStore.Data.Service;
using MovieStore.Desktop.Helper;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class LanguageListViewModel
    {
        ILanguageService _service;

        public LanguageListViewModel(ILanguageService service)
        {
            this._service = service;
        }

        public IList<Language> Get()
        {
            var result = _service.GetAll();

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _service.Delete(id, UserInfo.UserId);
        }
    }
}
