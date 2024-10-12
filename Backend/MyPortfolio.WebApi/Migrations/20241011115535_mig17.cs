using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "portfolioBlogId",
                table: "PortfolioComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments",
                column: "portfolioBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComments_portfolioBlogs_portfolioBlogId",
                table: "PortfolioComments",
                column: "portfolioBlogId",
                principalTable: "portfolioBlogs",
                principalColumn: "PortfolioBlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComments_portfolioBlogs_portfolioBlogId",
                table: "PortfolioComments");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments");

            migrationBuilder.DropColumn(
                name: "portfolioBlogId",
                table: "PortfolioComments");
        }
    }
}
