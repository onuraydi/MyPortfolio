using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComments_blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments",
                column: "blogCommentPortfolioBlogCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments",
                column: "blogCommentPortfolioBlogCommentId",
                principalTable: "PortfolioComments",
                principalColumn: "PortfolioBlogCommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioComments_blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments");

            migrationBuilder.DropColumn(
                name: "blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments");
        }
    }
}
