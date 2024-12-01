using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "PortfolioComments");

            migrationBuilder.RenameColumn(
                name: "blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments",
                newName: "ParentCommentIdPortfolioBlogCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioComments_blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments",
                newName: "IX_PortfolioComments_ParentCommentIdPortfolioBlogCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments",
                column: "ParentCommentIdPortfolioBlogCommentId",
                principalTable: "PortfolioComments",
                principalColumn: "PortfolioBlogCommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments");

            migrationBuilder.RenameColumn(
                name: "ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments",
                newName: "blogCommentPortfolioBlogCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioComments_ParentCommentIdPortfolioBlogCommentId",
                table: "PortfolioComments",
                newName: "IX_PortfolioComments_blogCommentPortfolioBlogCommentId");

            migrationBuilder.AddColumn<int>(
                name: "ParentCommentId",
                table: "PortfolioComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComments_PortfolioComments_blogCommentPortfolioBlogCommentId",
                table: "PortfolioComments",
                column: "blogCommentPortfolioBlogCommentId",
                principalTable: "PortfolioComments",
                principalColumn: "PortfolioBlogCommentId");
        }
    }
}
