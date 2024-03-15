using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editPriviledge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "RoleId",
            //    table: "Privilage");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Screens",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PrivilageType",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Screens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "PrivilageType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "JobId",
                table: "Privilage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Privilage_JobId",
                table: "Privilage",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Privilage_Jobs_JobId",
                table: "Privilage",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Privilage_Jobs_JobId",
                table: "Privilage");

            migrationBuilder.DropIndex(
                name: "IX_Privilage_JobId",
                table: "Privilage");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "PrivilageType");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Privilage");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Screens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "PrivilageType",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "Privilage",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
