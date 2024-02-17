using Dynamo.Context.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<DynamoRole>
    {
        public void Configure(EntityTypeBuilder<DynamoRole> builder)
        {
            builder.ToTable("Roles");
            builder.HasData
            ( 
                new DynamoRole()
                {
                    Id = "C37BA866-F045-4329-8264-333C7FABBC88", Name = "Admin",
                    ConcurrencyStamp = "1", NormalizedName = "Admin" ,
                    IsAdmin = true
                }
            );
        }
    }
}
