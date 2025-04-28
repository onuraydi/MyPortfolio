using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class canlimigbackend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorSurname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.BlogCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSeen = table.Column<bool>(type: "bit", nullable: false),
                    isBlog = table.Column<bool>(type: "bit", nullable: false),
                    Href = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioAboutMe",
                columns: table => new
                {
                    PortfolioAboutMeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonHref = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioAboutMe", x => x.PortfolioAboutMeId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioBlogs",
                columns: table => new
                {
                    PortfolioBlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSuggested = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioBlogs", x => x.PortfolioBlogId);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioBlogTags",
                columns: table => new
                {
                    PortfolioBlogTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioBlogTags", x => x.PortfolioBlogTagId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioCertificates",
                columns: table => new
                {
                    PortfolioCertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateDoneDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioCertificates", x => x.PortfolioCertificateId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioContacts",
                columns: table => new
                {
                    PortfolioContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioContacts", x => x.PortfolioContactId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioEducations",
                columns: table => new
                {
                    PortfolioEducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Average = table.Column<double>(type: "float", nullable: false),
                    EducationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioEducations", x => x.PortfolioEducationId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioExperiences",
                columns: table => new
                {
                    PortfolioExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioExperiences", x => x.PortfolioExperienceId);
                });

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

            migrationBuilder.CreateTable(
                name: "PortfolioMainTitles",
                columns: table => new
                {
                    PortfolioMainTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Button1Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Button2Href = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioMainTitles", x => x.PortfolioMainTitleId);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioProjectFooters",
                columns: table => new
                {
                    PortfolioProjectFooterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioProjectFooters", x => x.PortfolioProjectFooterId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioProjects",
                columns: table => new
                {
                    PortfolioProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectStartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectFinishDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectHref = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioProjects", x => x.PortfolioProjectId);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioRoutingFooters",
                columns: table => new
                {
                    PortfolioRoutingFooterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pageHref = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioRoutingFooters", x => x.PortfolioRoutingFooterId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioSkills",
                columns: table => new
                {
                    PortfolioSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillPercent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioSkills", x => x.PortfolioSkillId);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioSocialMediaFooters",
                columns: table => new
                {
                    PortfolioSocialMediaFooterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioSocialMediaFooters", x => x.PortfolioSocialMediaFooterId);
                });

            migrationBuilder.CreateTable(
                name: "portfolioTechnologies",
                columns: table => new
                {
                    PortfolioTechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioTechnologies", x => x.PortfolioTechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryBlog",
                columns: table => new
                {
                    PortfolioBlogId = table.Column<int>(type: "int", nullable: false),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBlog", x => new { x.PortfolioBlogId, x.BlogCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryBlog_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "BlogCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBlog_portfolioBlogs_PortfolioBlogId",
                        column: x => x.PortfolioBlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioComments",
                columns: table => new
                {
                    PortfolioBlogCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    portfolioBlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioComments", x => x.PortfolioBlogCommentId);
                    table.ForeignKey(
                        name: "FK_PortfolioComments_portfolioBlogs_portfolioBlogId",
                        column: x => x.portfolioBlogId,
                        principalTable: "portfolioBlogs",
                        principalColumn: "PortfolioBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                columns: table => new
                {
                    ProjectImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortfolioProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImages", x => x.ProjectImageId);
                    table.ForeignKey(
                        name: "FK_ProjectImages_portfolioProjects_PortfolioProjectId",
                        column: x => x.PortfolioProjectId,
                        principalTable: "portfolioProjects",
                        principalColumn: "PortfolioProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogsTags_PortfolioBlogTagId",
                table: "BlogsTags",
                column: "PortfolioBlogTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlog_BlogCategoryId",
                table: "CategoryBlog",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioComments_portfolioBlogId",
                table: "PortfolioComments",
                column: "portfolioBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_PortfolioProjectId",
                table: "ProjectImages",
                column: "PortfolioProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogsTags");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CategoryBlog");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "portfolioAboutMe");

            migrationBuilder.DropTable(
                name: "portfolioCertificates");

            migrationBuilder.DropTable(
                name: "PortfolioComments");

            migrationBuilder.DropTable(
                name: "portfolioContacts");

            migrationBuilder.DropTable(
                name: "portfolioEducations");

            migrationBuilder.DropTable(
                name: "portfolioExperiences");

            migrationBuilder.DropTable(
                name: "PortfolioFreelances");

            migrationBuilder.DropTable(
                name: "PortfolioMainTitles");

            migrationBuilder.DropTable(
                name: "PortfolioProjectFooters");

            migrationBuilder.DropTable(
                name: "PortfolioRoutingFooters");

            migrationBuilder.DropTable(
                name: "portfolioSkills");

            migrationBuilder.DropTable(
                name: "PortfolioSocialMediaFooters");

            migrationBuilder.DropTable(
                name: "portfolioTechnologies");

            migrationBuilder.DropTable(
                name: "ProjectImages");

            migrationBuilder.DropTable(
                name: "PortfolioBlogTags");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "portfolioBlogs");

            migrationBuilder.DropTable(
                name: "portfolioProjects");
        }
    }
}
