namespace Application.Core.DTOs.Role
{
    public class PermissionTreeDto
    {
        public long Key { get; set; }
        public string Label { get; set; }
        public List<PermissionTreeDto> Children { get; set; }
    }
}
