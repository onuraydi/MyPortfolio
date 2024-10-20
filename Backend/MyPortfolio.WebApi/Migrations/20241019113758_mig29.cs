using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image10",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image5",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image6",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image7",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image8",
                table: "portfolioProjects");

            migrationBuilder.DropColumn(
                name: "Image9",
                table: "portfolioProjects");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                columns: table => new
                {
                    ProjectImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImages", x => x.ProjectImageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectImages");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "portfolioProjects");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image10",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image5",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image6",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image7",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image8",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image9",
                table: "portfolioProjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
