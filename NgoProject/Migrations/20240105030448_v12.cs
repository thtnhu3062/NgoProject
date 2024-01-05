using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NgoProject.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsImage2",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsImage3",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "AdminPassword",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminPassword",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "NewsImage2",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsImage3",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
