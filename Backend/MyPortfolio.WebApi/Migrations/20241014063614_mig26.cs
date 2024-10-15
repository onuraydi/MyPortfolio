using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ButtonHref",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ButtonName",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "portfolioAboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "portfolioAboutMe");

            migrationBuilder.DropColumn(
                name: "ButtonHref",
                table: "portfolioAboutMe");

            migrationBuilder.DropColumn(
                name: "ButtonName",
                table: "portfolioAboutMe");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "portfolioAboutMe");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "portfolioAboutMe");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "portfolioAboutMe");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "portfolioAboutMe");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "portfolioAboutMe");
        }
    }
}
