﻿using System.ComponentModel.DataAnnotations;

namespace Faculty.AspUI.ViewModels.User
{
    public class UserEditPass
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [DataType(DataType.Password, ErrorMessage = "PasswordType")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "PasswordLength")]
        public string NewPassword { get; set; }
    }
}