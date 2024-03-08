using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPrivilage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privilage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreensId = table.Column<long>(type: "bigint", nullable: true),
                    PrivilageTypeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Privilage_PrivilageType_PrivilageTypeId",
                        column: x => x.PrivilageTypeId,
                        principalTable: "PrivilageType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Privilage_Screens_ScreensId",
                        column: x => x.ScreensId,
                        principalTable: "Screens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Privilage_PrivilageTypeId",
                table: "Privilage",
                column: "PrivilageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Privilage_ScreensId",
                table: "Privilage",
                column: "ScreensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Privilage");
        }
    }
}
