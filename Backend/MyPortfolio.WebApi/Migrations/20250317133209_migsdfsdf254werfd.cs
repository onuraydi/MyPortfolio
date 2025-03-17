using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migsdfsdf254werfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCategoryPortfolioBlog");

            migrationBuilder.DropTable(
                name: "PortfolioTagPortfolioBlog");

            migrationBuilder.AddColumn<int>(
                name: "BlogCategoryId",
                table: "portfolioBlogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogsTags",
                columns: table => new
                {
                    PortfolioBlogId = table.Column<int>(type: "int", nullable: false),
                    PortfolioBlogTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsTags", x => new { x.PortfolioBlogId, x.PortfolioBlogTagId });
                    table.ForeignKey(
                        name: "FK_BlogsTags_PortfolioBlogTags_PortfolioBlogTagId",
                        column: x => x.PortfolioBlogTagId,
                        principalTable: "PortfolioBlogTags",
                        principalColumn: "PortfolioBlogTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogsTags_portfolioBlogs_PortfolioBlogId",
                        column: x => x.PortfolioBlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolioBlogs_BlogCategoryId",
                table: "portfolioBlogs",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsTags_PortfolioBlogTagId",
                table: "BlogsTags",
                column: "PortfolioBlogTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioBlogs_BlogCategories_BlogCategoryId",
                table: "portfolioBlogs",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolioBlogs_BlogCategories_BlogCategoryId",
                table: "portfolioBlogs");

            migrationBuilder.DropTable(
                name: "BlogsTags");

            migrationBuilder.DropIndex(
                name: "IX_portfolioBlogs_BlogCategoryId",
                table: "portfolioBlogs");

            migrationBuilder.DropColumn(
                name: "BlogCategoryId",
                table: "portfolioBlogs");

            migrationBuilder.CreateTable(
                name: "BlogCategoryPortfolioBlog",
                columns: table => new
                {
                    BlogCategoriesBlogCategoryId = table.Column<int>(type: "int", nullable: false),
                    PortfolioBlogsPortfolioBlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategoryPortfolioBlog", x => new { x.BlogCategoriesBlogCategoryId, x.PortfolioBlogsPortfolioBlogId });
                    table.ForeignKey(
                        name: "FK_BlogCategoryPortfolioBlog_BlogCategories_BlogCategoriesBlogCategoryId",
                        column: x => x.BlogCategoriesBlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "BlogCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCategoryPortfolioBlog_portfolioBlogs_PortfolioBlogsPortfolioBlogId",
                        column: x => x.PortfolioBlogsPortfolioBlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioTagPortfolioBlog",
                columns: table => new
                {
                    PortfolioBlogId = table.Column<int>(type: "int", nullable: false),
                    PortfolioBlogTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioTagPortfolioBlog", x => new { x.PortfolioBlogId, x.PortfolioBlogTagId });
                    table.ForeignKey(
                        name: "FK_PortfolioTagPortfolioBlog_PortfolioBlogTags_PortfolioBlogTagId",
                        column: x => x.PortfolioBlogTagId,
                        principalTable: "PortfolioBlogTags",
                        principalColumn: "PortfolioBlogTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioTagPortfolioBlog_portfolioBlogs_PortfolioBlogId",
                        column: x => x.PortfolioBlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryPortfolioBlog_PortfolioBlogsPortfolioBlogId",
                table: "BlogCategoryPortfolioBlog",
                column: "PortfolioBlogsPortfolioBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioTagPortfolioBlog_PortfolioBlogTagId",
                table: "PortfolioTagPortfolioBlog",
                column: "PortfolioBlogTagId");
        }
    }
}
