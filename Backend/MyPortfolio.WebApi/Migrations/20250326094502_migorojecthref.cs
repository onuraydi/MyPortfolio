using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migorojecthref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectHref",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectHref",
                table: "portfolioProjects");
        }
    }
}
