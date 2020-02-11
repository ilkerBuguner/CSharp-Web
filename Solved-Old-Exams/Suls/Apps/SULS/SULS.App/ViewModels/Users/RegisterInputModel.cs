using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Users
{
    public class RegisterInputModel
    {
        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters")]
        [RequiredSis]
        public string Username { get; set; }

        [RequiredSis]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
