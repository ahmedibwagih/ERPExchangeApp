using Core.Other;
using Dynamo.Context.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<DynamoUser>
    {
        private readonly IPasswordHasher<DynamoUser> passwordHasher;

        public UserConfiguration(IPasswordHasher<DynamoUser> passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }

        public void Configure(EntityTypeBuilder<DynamoUser> builder)
        {
            builder.ToTable("Users");

            var user = new DynamoUser()
            {
                Id = "9702DAFA-3A8E-4E4C-AADD-16B702AAFDCC",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PasswordHash = "AQAAAAEAACcQAAAAEKeHbwz9ifJ/7QF5bYDb8Yexqm9D++pSz9gVA8u0jHAyVWFjDla0t9cbFpOxPy3JpA==", //Default@123
                SecurityStamp = "R3XT5SFLH6DQLP4IZMAWSHZFSIUWADTI",
                ConcurrencyStamp = "bcdbea3a-af4c-4b3c-8bf7-51f4f26ac35f",
                Type =0
            };


            builder.HasData
            (
                user
            );
        }
    }

}
