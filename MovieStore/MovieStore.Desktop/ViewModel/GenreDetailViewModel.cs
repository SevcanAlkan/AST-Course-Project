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
    public class GenreDetailViewModel
    {
        private IGenreService _service;

        public GenreDetailViewModel(IGenreService service)
        {
            this._service = service;
        }

        public Guid Id { get; set; }

        public Genre Rec { get; set; }

        public void LoadRec(Guid id)
        {
            this.Id = id;
            Rec = new Genre();

            if (Id != null && !Id.IsNotValid())
            {
                var dto = _service.GetById(Id);

                if (dto != null)
                {
                    Rec = dto;
                }
            }
        }

        public void SetId(Guid id)
        {
            this.Id = id;
        }

        public void Clean()
        {
            Id = Guid.Empty;
            Rec = new Genre();
        }

        public async Task<Genre> Add()
        {
            return await _service.Add(Rec, UserInfo.UserId);
        }

        public async Task<Genre> Update()
        {
            return await _service.Update(Id, Rec, UserInfo.UserId);
        }
    }
}
