using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migcats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolioBlogs_BlogCategories_BlogCategoryId",
                table: "portfolioBlogs");

            migrationBuilder.DropIndex(
                name: "IX_portfolioBlogs_BlogCategoryId",
                table: "portfolioBlogs");

            migrationBuilder.DropColumn(
                name: "BlogCategoryId",
                table: "portfolioBlogs");

            migrationBuilder.CreateTable(
                name: "CategoryBlog",
                columns: table => new
                {
                    PortfolioBlogId = table.Column<int>(type: "int", nullable: false),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBlog", x => new { x.PortfolioBlogId, x.BlogCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryBlog_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "BlogCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBlog_portfolioBlogs_PortfolioBlogId",
                        column: x => x.PortfolioBlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlog_BlogCategoryId",
                table: "CategoryBlog",
                column: "BlogCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryBlog");

            migrationBuilder.AddColumn<int>(
                name: "BlogCategoryId",
                table: "portfolioBlogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_portfolioBlogs_BlogCategoryId",
                table: "portfolioBlogs",
                column: "BlogCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioBlogs_BlogCategories_BlogCategoryId",
                table: "portfolioBlogs",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "BlogCategoryId");
        }
    }
}
