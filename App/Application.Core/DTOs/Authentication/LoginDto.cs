using System.ComponentModel.DataAnnotations;

namespace Application.Core.DTOs.Authentication
{
    public class LoginDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    public class LoginSocialDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "SocialToke is required")]
        public string SocialToke { get; set; }

        [Required(ErrorMessage = "Social type is required")]
        public SocialType SocialType { get; set; }
    }

    public enum SocialType
    {
        Google=0, Facebook=1, Apple=2
    }
}
