using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migas2sd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryBlog");

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

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryPortfolioBlog_PortfolioBlogsPortfolioBlogId",
                table: "BlogCategoryPortfolioBlog",
                column: "PortfolioBlogsPortfolioBlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCategoryPortfolioBlog");

            migrationBuilder.CreateTable(
                name: "CategoryBlog",
                columns: table => new
                {
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBlog", x => new { x.BlogCategoryId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_CategoryBlog_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "BlogCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBlog_portfolioBlogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlog_BlogId",
                table: "CategoryBlog",
                column: "BlogId");
        }
    }
}
