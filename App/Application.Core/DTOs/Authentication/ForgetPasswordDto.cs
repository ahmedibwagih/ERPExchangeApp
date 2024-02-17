using System.ComponentModel.DataAnnotations;

namespace Application.Core.DTOs.Authentication
{
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
    }
}
