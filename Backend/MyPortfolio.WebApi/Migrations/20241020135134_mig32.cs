using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortfolioProjectId",
                table: "ProjectImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_PortfolioProjectId",
                table: "ProjectImages",
                column: "PortfolioProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImages_portfolioProjects_PortfolioProjectId",
                table: "ProjectImages",
                column: "PortfolioProjectId",
                principalTable: "portfolioProjects",
                principalColumn: "PortfolioProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImages_portfolioProjects_PortfolioProjectId",
                table: "ProjectImages");

            migrationBuilder.DropIndex(
                name: "IX_ProjectImages_PortfolioProjectId",
                table: "ProjectImages");

            migrationBuilder.DropColumn(
                name: "PortfolioProjectId",
                table: "ProjectImages");
        }
    }
}
