using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments");

            migrationBuilder.DropColumn(
                name: "BlogCommentId",
                table: "portfolioBlogs");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments",
                column: "portfolioBlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments");

            migrationBuilder.AddColumn<int>(
                name: "BlogCommentId",
                table: "portfolioBlogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments",
                column: "portfolioBlogId",
                unique: true);
        }
    }
}
