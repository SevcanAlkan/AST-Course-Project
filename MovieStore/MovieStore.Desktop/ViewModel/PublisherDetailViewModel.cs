using MovieStore.Core.Validation;
using MovieStore.Data.Service;
using MovieStore.Desktop.Helper;
using MovieStore.Domain;
using System;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class PublisherDetailViewModel
    {
        private IPublisherService _service;

        public PublisherDetailViewModel(IPublisherService service)
        {
            this._service = service;
        }

        public Guid Id { get; set; }

        public Publisher Rec { get; set; }

        public void LoadRec(Guid id)
        {
            this.Id = id;
            Rec = new Publisher();

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
            Rec = new Publisher();
        }

        public async Task<Publisher> Add()
        {
            return await _service.Add(Rec, UserInfo.UserId);
        }

        public async Task<Publisher> Update()
        {
            return await _service.Update(Id, Rec, UserInfo.UserId);
        }
    }
}
