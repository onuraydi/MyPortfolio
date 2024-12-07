using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioBlogTags_portfolioBlogs_PortfolioBlogId",
                table: "PortfolioBlogTags");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioBlogTags_PortfolioBlogId",
                table: "PortfolioBlogTags");

            migrationBuilder.DropColumn(
                name: "PortfolioBlogId",
                table: "PortfolioBlogTags");

            migrationBuilder.CreateTable(
                name: "BlogsTags",
                columns: table => new
                {
                    PortfolioBlogId = table.Column<int>(type: "int", nullable: false),
                    PortfolioBlogTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsTags", x => new { x.PortfolioBlogId, x.PortfolioBlogTagId });
                    table.ForeignKey(
                        name: "FK_BlogsTags_PortfolioBlogTags_PortfolioBlogTagId",
                        column: x => x.PortfolioBlogTagId,
                        principalTable: "PortfolioBlogTags",
                        principalColumn: "PortfolioBlogTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogsTags_portfolioBlogs_PortfolioBlogId",
                        column: x => x.PortfolioBlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogsTags_PortfolioBlogTagId",
                table: "BlogsTags",
                column: "PortfolioBlogTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogsTags");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioBlogId",
                table: "PortfolioBlogTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioBlogTags_PortfolioBlogId",
                table: "PortfolioBlogTags",
                column: "PortfolioBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioBlogTags_portfolioBlogs_PortfolioBlogId",
                table: "PortfolioBlogTags",
                column: "PortfolioBlogId",
                principalTable: "portfolioBlogs",
                principalColumn: "PortfolioBlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
