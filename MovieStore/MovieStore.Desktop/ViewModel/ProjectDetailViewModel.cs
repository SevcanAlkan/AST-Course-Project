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
    public class ProjectDetailViewModel
    {
        private IProjectService _service;

        public ProjectDetailViewModel(IProjectService service)
        {
            this._service = service;
        }

        public Guid Id { get; set; }

        public Project Rec { get; set; }

        public void LoadRec(Guid id)
        {
            this.Id = id;
            Rec = new Project();

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
            Rec = new Project();
        }

        public async Task<Project> Add()
        {
            return await _service.Add(Rec, UserInfo.UserId);
        }

        public async Task<Project> Update()
        {
            return await _service.Update(Id, Rec, UserInfo.UserId);
        }
    }
}
