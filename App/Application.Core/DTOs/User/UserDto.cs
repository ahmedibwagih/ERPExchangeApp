using System.ComponentModel.DataAnnotations;

namespace Application.Core.DTOs.User
{
    public class UserDto
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

      //  [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public long JobId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string PhoneNumber { get; set; }
        public IList<UserRoleDto>? UserRoles { get; set; }

    }
}
