using MovieStore.Core.Enum;
using MovieStore.Data.Service;
using MovieStore.Data.ViewModel;
using MovieStore.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class ProjectListViewModel
    {
        IProjectService _service;

        public ProjectListViewModel(IProjectService service)
        {
            this._service = service;
        }

        public IList<ProjectVM> Get(DateTime? startDate = null, DateTime? endDate = null, Guid? movieId = null, ProjectStatus? status = null, Guid? languageId = null, bool showIsDeleted = false)
        {
            return _service.GetList(startDate, endDate, movieId, status, languageId, showIsDeleted);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _service.Delete(id, UserInfo.UserId);
        }
    }
}
