using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migmarksuggested : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSuggested",
                table: "portfolioBlogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSuggested",
                table: "portfolioBlogs");
        }
    }
}
