﻿using System.ComponentModel.DataAnnotations;

namespace MTRSalesBoard.Models
{
    public class CreateUserViewModel
    {
        /* This viewmodel is used to maintain validation from the form when the user is created */
        #region Properties
        [Required(ErrorMessage = "Name is required")]
        [UIHint("Full Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passwords must contain one uppercase, one lowercase, one number and one special character")]
        public string Password { get; set; }
        #endregion
    }
}
