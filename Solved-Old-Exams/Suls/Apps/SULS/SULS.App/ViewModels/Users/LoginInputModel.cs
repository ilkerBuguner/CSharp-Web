using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Users
{
    public class LoginInputModel
    {
        [StringLengthSis(5,20, "Username should be between 5 and 20 characters")]
        [RequiredSis]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, "Password should be between 6 and 20 characters")]
        public string Password { get; set; }
    }
}
