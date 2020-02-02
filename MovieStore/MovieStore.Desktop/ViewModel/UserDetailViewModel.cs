using MovieStore.Core.Validation;
using MovieStore.Data.Service;
using MovieStore.Desktop.Helper;
using MovieStore.Domain;
using System;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class UserDetailViewModel
    {
        private IUserService _service;

        public UserDetailViewModel(IUserService service)
        {
            this._service = service;
        }

        public Guid Id { get; set; }

        public User Rec { get; set; }

        public void LoadRec(Guid id)
        {
            this.Id = id;
            Rec = new User();

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
            Rec = new User();
        }

        public async Task<User> Add()
        {
            return await _service.Add(Rec, UserInfo.UserId);
        }

        public async Task<User> Update()
        {
            return await _service.Update(Id, Rec, UserInfo.UserId);
        }
    }
}
