using MovieStore.Core.Enum;
using MovieStore.Data.Service;
using MovieStore.Data.ViewModel;
using MovieStore.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class MovieListViewModel
    {
        IMovieService _service;

        public MovieListViewModel(IMovieService service)
        {
            this._service = service;
        }

        public IList<MovieVM> Get(int? year = null, Guid? languageId = null, Guid? publisherId = null, bool showIsDeleted = false)
        {
            return _service.GetList(year, languageId, publisherId, showIsDeleted);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _service.Delete(id, UserInfo.UserId);
        }
    }
}
