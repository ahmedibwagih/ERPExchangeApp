using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPrivilageType3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Notifications",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreateUser = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
            //        CreateUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        UpdateUser = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
            //        UpdateUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        NotificationType = table.Column<int>(type: "int", nullable: false),
            //        DataId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DataDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsRead = table.Column<bool>(type: "bit", nullable: false),
            //        IsPending = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notifications", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Permissions",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        Desc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Permissions", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsAdmin = table.Column<bool>(type: "bit", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Screens",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        IsFinal = table.Column<bool>(type: "bit", nullable: false),
            //        ScreenParrentId = table.Column<long>(type: "bigint", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Screens", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TypeId = table.Column<long>(type: "bigint", nullable: true),
            //        Type = table.Column<int>(type: "int", nullable: true),
            //        CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RolePermissions",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        PermissionId = table.Column<long>(type: "bigint", nullable: false),
            //        PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RolePermissions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RolePermissions_Permissions_PermissionId",
            //            column: x => x.PermissionId,
            //            principalTable: "Permissions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_RolePermissions_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateTable(
                name: "PrivilageType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreensId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilageType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivilageType_Screens_ScreensId",
                        column: x => x.ScreensId,
                        principalTable: "Screens",
                        principalColumn: "Id");
                });

            //migrationBuilder.CreateTable(
            //    name: "UserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_UserRoles_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserRoles_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "CreateDate", "CreateUser", "CreateUserName", "DeleteUserId", "IsAdmin", "IsDeleted", "Name", "NormalizedName", "UpdateDate", "UpdateUser", "UpdateUserName" },
            //    values: new object[] { "C37BA866-F045-4329-8264-333C7FABBC88", "1", null, null, null, null, true, false, "Admin", "Admin", null, null, null });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "CreateUser", "CreateUserName", "DeleteUserId", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "TypeId", "UpdateDate", "UpdateUser", "UpdateUserName", "UserName" },
            //    values: new object[] { "9702DAFA-3A8E-4E4C-AADD-16B702AAFDCC", 0, "bcdbea3a-af4c-4b3c-8bf7-51f4f26ac35f", null, null, null, null, "admin@admin.com", false, null, false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEKeHbwz9ifJ/7QF5bYDb8Yexqm9D++pSz9gVA8u0jHAyVWFjDla0t9cbFpOxPy3JpA==", "1234567890", false, "R3XT5SFLH6DQLP4IZMAWSHZFSIUWADTI", false, 1, null, null, null, null, "admin" });

            //migrationBuilder.InsertData(
            //    table: "UserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "C37BA866-F045-4329-8264-333C7FABBC88", "9702DAFA-3A8E-4E4C-AADD-16B702AAFDCC" });

            migrationBuilder.CreateIndex(
                name: "IX_PrivilageType_ScreensId",
                table: "PrivilageType",
                column: "ScreensId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RolePermissions_PermissionId",
            //    table: "RolePermissions",
            //    column: "PermissionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RolePermissions_RoleId",
            //    table: "RolePermissions",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "Roles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRoles_RoleId",
            //    table: "UserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "Users",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "Users",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PrivilageType");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
