using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migsdsdfdrg44543 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogsTags");

            migrationBuilder.CreateTable(
                name: "PortfolioTagPortfolioBlog",
                columns: table => new
                {
                    PortfolioBlogTagId = table.Column<int>(type: "int", nullable: false),
                    PortfolioBlogId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_PortfolioTagPortfolioBlog_PortfolioBlogTagId",
                table: "PortfolioTagPortfolioBlog",
                column: "PortfolioBlogTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioTagPortfolioBlog");

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
                name: "IX_BlogsTags_PortfolioBlogTagId",
                table: "BlogsTags",
                column: "PortfolioBlogTagId");
        }
    }
}
