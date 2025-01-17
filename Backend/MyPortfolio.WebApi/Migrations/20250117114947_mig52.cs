using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig52 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortfolioFreelances",
                columns: table => new
                {
                    PortfolioFreelanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonHref = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioFreelances", x => x.PortfolioFreelanceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioFreelances");
        }
    }
}
