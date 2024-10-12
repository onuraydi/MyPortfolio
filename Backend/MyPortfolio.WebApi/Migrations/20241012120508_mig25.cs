using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectButtonHref",
                table: "PortfolioMainTitles",
                newName: "ButtonName2");

            migrationBuilder.RenameColumn(
                name: "HireMeButtonHref",
                table: "PortfolioMainTitles",
                newName: "ButtonName1");

            migrationBuilder.AddColumn<string>(
                name: "Button1Href",
                table: "PortfolioMainTitles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Button2Href",
                table: "PortfolioMainTitles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Button1Href",
                table: "PortfolioMainTitles");

            migrationBuilder.DropColumn(
                name: "Button2Href",
                table: "PortfolioMainTitles");

            migrationBuilder.RenameColumn(
                name: "ButtonName2",
                table: "PortfolioMainTitles",
                newName: "ProjectButtonHref");

            migrationBuilder.RenameColumn(
                name: "ButtonName1",
                table: "PortfolioMainTitles",
                newName: "HireMeButtonHref");
        }
    }
}
