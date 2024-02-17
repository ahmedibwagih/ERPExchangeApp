using System.ComponentModel.DataAnnotations;

namespace Application.Core.DTOs.Authentication
{
    public class CompleteForgetPasswordDto
    {
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Verfication Code is required")]
        public string VerficationCode { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
    }
}
