using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataConfiguration
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasData
            (
                new IdentityUserRole<string>()
                {
                    
                    RoleId = "C37BA866-F045-4329-8264-333C7FABBC88",
                    UserId = "9702DAFA-3A8E-4E4C-AADD-16B702AAFDCC",
                }
            );
        }
    }

}
