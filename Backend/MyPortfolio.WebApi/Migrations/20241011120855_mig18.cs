using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioComments_portfolioBlogs_portfolioBlogId",
                table: "PortfolioComments");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments");

            migrationBuilder.AlterColumn<int>(
                name: "portfolioBlogId",
                table: "PortfolioComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments",
                column: "portfolioBlogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioComments_portfolioBlogs_portfolioBlogId",
                table: "PortfolioComments",
                column: "portfolioBlogId",
                principalTable: "portfolioBlogs",
                principalColumn: "PortfolioBlogId",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "portfolioBlogId",
                table: "PortfolioComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
