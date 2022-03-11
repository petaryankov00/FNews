using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FNews.Data.Migrations
{
    public partial class ChangeNameOfTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsNews_Articles_ArticleId",
                table: "TeamsNews");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsNews_Teams_TeamId",
                table: "TeamsNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsNews",
                table: "TeamsNews");

            migrationBuilder.RenameTable(
                name: "TeamsNews",
                newName: "TeamsArticles");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsNews_ArticleId",
                table: "TeamsArticles",
                newName: "IX_TeamsArticles_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsArticles",
                table: "TeamsArticles",
                columns: new[] { "TeamId", "ArticleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsArticles_Articles_ArticleId",
                table: "TeamsArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsArticles_Teams_TeamId",
                table: "TeamsArticles",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsArticles_Articles_ArticleId",
                table: "TeamsArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsArticles_Teams_TeamId",
                table: "TeamsArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsArticles",
                table: "TeamsArticles");

            migrationBuilder.RenameTable(
                name: "TeamsArticles",
                newName: "TeamsNews");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsArticles_ArticleId",
                table: "TeamsNews",
                newName: "IX_TeamsNews_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsNews",
                table: "TeamsNews",
                columns: new[] { "TeamId", "ArticleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsNews_Articles_ArticleId",
                table: "TeamsNews",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsNews_Teams_TeamId",
                table: "TeamsNews",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
