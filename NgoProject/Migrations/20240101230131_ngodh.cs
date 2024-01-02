using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NgoProject.Migrations
{
    /// <inheritdoc />
    public partial class ngodh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aboutus",
                columns: table => new
                {
                    AboutusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutusImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutusContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aboutus", x => x.AboutusId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    IdOne = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageOne = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.IdOne);
                });

            migrationBuilder.CreateTable(
                name: "Bannersses",
                columns: table => new
                {
                    IdTwo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTwo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bannersses", x => x.IdTwo);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Ourpartners",
                columns: table => new
                {
                    OurpartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OurpartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurpartnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurpartnerLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurpartnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurpartnerAddressWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurpartnerMail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ourpartners", x => x.OurpartnerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    OurpartnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_News_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_News_Ourpartners_OurpartnerId",
                        column: x => x.OurpartnerId,
                        principalTable: "Ourpartners",
                        principalColumn: "OurpartnerId");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FeedbackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Donates",
                columns: table => new
                {
                    DonateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(type: "int", nullable: true),
                    DonateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DonateMoney = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donates", x => x.DonateId);
                    table.ForeignKey(
                        name: "FK_Donates_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId");
                    table.ForeignKey(
                        name: "FK_Donates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donates_NewsId",
                table: "Donates",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Donates_UserId",
                table: "Donates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_News_OurpartnerId",
                table: "News",
                column: "OurpartnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aboutus");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Bannersses");

            migrationBuilder.DropTable(
                name: "Donates");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ourpartners");
        }
    }
}
