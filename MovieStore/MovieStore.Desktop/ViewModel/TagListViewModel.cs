﻿using MovieStore.Core.Validation;
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
    public class TagListViewModel
    {
        ITagService _service;

        public TagListViewModel(ITagService service)
        {
            this._service = service;
        }

        public IList<Tag> Get()
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