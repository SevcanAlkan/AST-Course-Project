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
    public class LanguageDetailViewModel
    {
        private ILanguageService _service;

        public LanguageDetailViewModel(ILanguageService service)
        {
            this._service = service;
        }

        public Guid Id { get; set; }

        public Language Rec { get; set; }

        public void LoadRec(Guid id)
        {
            this.Id = id;
            Rec = new Language();

            if (Id != null && !Id.IsNotValid())
            {
                var dto = _service.GetById(Id);

                if (dto != null)
                {
                    Rec = dto;
                }
            }
        }

        public void Clean()
        {
            Id = Guid.Empty;
            Rec = new Language();
        }

        public async Task<Language> Add()
        {
            return await _service.Add(Rec, UserInfo.UserId);
        }

        public async Task<Language> Update()
        {
            return await _service.Update(Id, Rec, UserInfo.UserId);
        }
    }
}
