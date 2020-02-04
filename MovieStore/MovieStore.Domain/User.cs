using MovieStore.Core.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Domain
{
    public class UserBase : BaseEntity //, IDataErrorInfo
    {
        [Required, MaxLength(20)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string DisplayName { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }

        // #175: The task cancelled!
        #region IDataErrorInfo Members

        //public string Error
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string result = null;
        //        if (columnName == "UserName")
        //        {
        //            if (string.IsNullOrEmpty(UserName))
        //                result = "Please enter a username";
        //            else if(UserName.Length > 20)
        //                result = "Username must be less than 20 charecters";
        //        }
        //        if (columnName == "DisplayName")
        //        {
        //            if (string.IsNullOrEmpty(DisplayName))
        //                result = "Please enter a display name";
        //            else if (DisplayName.Length > 50)
        //                result = "Display name must be less than 50 charecters";
        //        }
        //        if (columnName == "Password")
        //        {
        //            if (string.IsNullOrEmpty(Password))
        //                result = "Please enter a password";
        //            else if (Password.Length > 50)
        //                result = "Password must be less than 50 charecters";
        //        }
        //        return result;
        //    }
        //}

        #endregion
    }

    public class User : UserBase
    {

        //Foreign keys...

        public User()
        {
        }
    }
}
