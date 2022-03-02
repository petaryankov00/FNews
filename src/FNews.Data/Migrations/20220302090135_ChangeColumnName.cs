using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNews.Data.Migrations
{
    public partial class ChangeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Source",
                table: "News",
                newName: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "News",
                newName: "Source");
        }
    }
}
