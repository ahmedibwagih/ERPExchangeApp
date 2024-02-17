namespace Application.Core.DTOs.User
{
    public class UserAllDto
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public long? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
