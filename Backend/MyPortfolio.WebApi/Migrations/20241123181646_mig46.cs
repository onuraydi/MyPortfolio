using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig46 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioComments_ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments");

            migrationBuilder.DropColumn(
                name: "ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComments_ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments",
                column: "ParentCommentIdPortfolioBlogCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments",
                column: "ParentCommentIdPortfolioBlogCommentId",
                principalTable: "PortfolioComments",
                principalColumn: "PortfolioBlogCommentId");
        }
    }
}
