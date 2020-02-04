using MovieStore.Data.Service;
using MovieStore.Domain;
using System.Linq;

namespace MovieStore.Desktop.ViewModel
{
    public class LoginViewModel
    {
        IUserService _service;

        public LoginViewModel(IUserService service)
        {
            this._service = service;
        }

        public User Login(string userName, string password)
        {
            if (userName == null || userName == "" || password == null || password == "")
                return null;

            var _rec = _service.GetAll().Where(a => a.UserName == userName && a.Password == password).FirstOrDefault();

            return _rec;
        }
    }
}
