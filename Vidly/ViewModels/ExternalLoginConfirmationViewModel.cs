using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [MaxLength(50, ErrorMessage = "Phone number can consist of maximum 50 characters.")]
        [MinLength(10, ErrorMessage = "Phone number must have atleast 10 characters.")]
        public string Phone { get; set; }
    }
}