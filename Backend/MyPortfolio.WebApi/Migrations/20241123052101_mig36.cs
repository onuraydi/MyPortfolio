using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentRate",
                table: "PortfolioComments");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "PortfolioComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "PortfolioComments");

            migrationBuilder.AddColumn<double>(
                name: "CommentRate",
                table: "PortfolioComments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
