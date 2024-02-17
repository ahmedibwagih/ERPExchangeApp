using Dynamo.Context.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dynamo.Context.ModelConfiguration
{
    public class DynamoRoleMapping : IEntityTypeConfiguration<DynamoRole>
    {
        public void Configure(EntityTypeBuilder<DynamoRole> builder)
        {
            builder.ToTable(name: "Roles");

        }
    }
}