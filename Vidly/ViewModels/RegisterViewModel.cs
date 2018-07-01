﻿using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Phone Number")]
        [MaxLength(50, ErrorMessage = "Phone number can consist of maximum 50 characters.")]
        [MinLength(10, ErrorMessage = "Phone number must have atleast 10 characters.")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}