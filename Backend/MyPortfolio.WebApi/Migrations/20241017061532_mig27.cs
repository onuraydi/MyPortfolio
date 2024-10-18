using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Href",
                table: "portfolioTechnologies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Href",
                table: "portfolioTechnologies");
        }
    }
}
