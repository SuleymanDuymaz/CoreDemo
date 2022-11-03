using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class rayting_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogRaytingScore",
                table: "BlogRaytings",
                newName: "BlogRaytingCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogRaytingCount",
                table: "BlogRaytings",
                newName: "BlogRaytingScore");
        }
    }
}
