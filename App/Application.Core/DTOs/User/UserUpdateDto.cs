using System.ComponentModel.DataAnnotations;

namespace Application.Core.DTOs.User
{
    public class UserUpdateDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public IList<UserRoleDto> UserRoles { get; set; }
    }
}
