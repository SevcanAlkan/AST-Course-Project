using MovieStore.Core.Validation;
using MovieStore.Data.Service;
using MovieStore.Desktop.Helper;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class GenreListViewModel
    {
        IGenreService _service;

        public GenreListViewModel(IGenreService service)
        {
            this._service = service;
        }

        public IList<Genre> Get()
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
