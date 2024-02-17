using Dynamo.Context.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dynamo.Context.ModelConfiguration
{
    public class DynamoUserMapping : IEntityTypeConfiguration<DynamoUser>
    {
        public void Configure(EntityTypeBuilder<DynamoUser> builder)
        {
            builder.ToTable(name: "Users");
            builder
               .HasMany(u => u.UserRoles)
               .WithMany(r => r.Users)
               .UsingEntity<IdentityUserRole<string>>(
                   userRole => userRole.HasOne<DynamoRole>()
                       .WithMany()
                       .HasForeignKey(ur => ur.RoleId)
                       .IsRequired(),
                   userRole => userRole.HasOne<DynamoUser>()
                       .WithMany()
                       .HasForeignKey(ur => ur.UserId)
                       .IsRequired()
               );

        }
    }
}
