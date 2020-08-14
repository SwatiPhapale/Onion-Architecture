using RepoProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoProject.Core.DTOs
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Please Enter UserName")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Assigned_Manager { get; set; }
        public string License { get; set; }
        public DateTime Created { get; set; }
       

        public UserRegisterDto()
        {
            Created = DateTime.Now;
        }
    }
}
