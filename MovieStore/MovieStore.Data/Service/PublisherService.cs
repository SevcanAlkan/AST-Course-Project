using MovieStore.Data.SubStructure;
using MovieStore.Data.ViewModel;
using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Data.Service
{
    public class PublisherService : BaseService<Publisher>, IPublisherService
    {
        #region Ctor

        public PublisherService(IRepository<Publisher> repository)
            : base(repository)
        {

        }

        #endregion

        #region Methods

        public List<SelectListVM<Guid>> GetSelectList()
        {
            return this.AsQueryable()
                .Where(a => a.IsDeleted == false)
                .Select(s => new SelectListVM<Guid>()
                {
                    Value = s.Id,
                    Text = s.Name
                }).ToList();
        }

        #endregion
    }

    public interface IPublisherService : IBaseService<Publisher>
    {
        List<SelectListVM<Guid>> GetSelectList();
    }
}
