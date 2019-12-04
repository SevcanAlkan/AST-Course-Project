using MovieStore.Data.Service;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class GenreViewModel
    {
        IGenreService _service;

        public GenreViewModel(IGenreService service)
        {
            this._service = service;
        }

        public IList<Genre> Get()
        {
            var result = _service.GetAll();

            return result;
        }
    }
}
