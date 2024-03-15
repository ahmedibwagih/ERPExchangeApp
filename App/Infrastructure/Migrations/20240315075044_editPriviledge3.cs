using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editPriviledge3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Screens",
                newName: "ScreenId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PrivilageType",
                newName: "PrivilageTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScreenId",
                table: "Screens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PrivilageTypeId",
                table: "PrivilageType",
                newName: "Id");
        }
    }
}
