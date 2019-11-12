using MovieStore.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Desktop.ViewModel
{
    public class LoginViewModel 
    {
        IUserService _service;

        public LoginViewModel(IUserService service)
        {
            this._service = service;
        }

       
    }
}
