using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolioProjects_ProjectImages_ProjectImageId",
                table: "portfolioProjects");

            migrationBuilder.DropIndex(
                name: "IX_portfolioProjects_ProjectImageId",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "ProjectImageId",
                table: "portfolioProjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectImageId",
                table: "portfolioProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_portfolioProjects_ProjectImageId",
                table: "portfolioProjects",
                column: "ProjectImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioProjects_ProjectImages_ProjectImageId",
                table: "portfolioProjects",
                column: "ProjectImageId",
                principalTable: "ProjectImages",
                principalColumn: "ProjectImageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
