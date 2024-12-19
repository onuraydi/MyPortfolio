using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Entites;
using MyPortfolio.WebApi.Entites.LibraryEntities;

namespace MyPortfolio.WebApi.Context
{
    public class PortfolioContext:DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options):base(options) { }

        public DbSet<PortfolioMainTitle> PortfolioMainTitles { get; set; }
        public DbSet<PortfolioAboutMe> portfolioAboutMe { get; set; }
        public DbSet<PortfolioExperience> portfolioExperiences { get; set; }
        public DbSet<PortfolioSkill> portfolioSkills { get; set; }
        public DbSet<PortfolioCertificate> portfolioCertificates { get; set; }
        public DbSet<PortfolioEducation> portfolioEducations { get; set; }
        public DbSet<PortfolioProject> portfolioProjects { get; set; }
        public DbSet<PortfolioTechnology> portfolioTechnologies { get; set; }
        public DbSet<PortfolioBlog> portfolioBlogs { get; set; }
        public DbSet<PortfolioBlogComment> PortfolioComments { get; set; }
        public DbSet<PortfolioContact> portfolioContacts { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<PortfolioBlogTag> PortfolioBlogTags { get; set; }
        public DbSet<PortfolioSocialMediaFooter> PortfolioSocialMediaFooters { get; set; }

        // Library parts
        public DbSet<Book> Books {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioProject>()
                .HasMany(x => x.Images)
                .WithOne(y => y.PortfolioProject)
                .HasForeignKey(z => z.PortfolioProjectId)
                .IsRequired(true);
            modelBuilder.Entity<PortfolioBlog>()
                .HasMany(x => x.PortfolioBlogTags)
                .WithMany(y => y.PortfolioBlogs)
                .UsingEntity(
                    "BlogsTags",
                    l => l.HasOne(typeof(PortfolioBlogTag)).WithMany().HasForeignKey("PortfolioBlogTagId").HasPrincipalKey(nameof(PortfolioBlogTag.PortfolioBlogTagId)),
                    m => m.HasOne(typeof(PortfolioBlog)).WithMany().HasForeignKey("PortfolioBlogId").HasPrincipalKey(nameof(PortfolioBlog.PortfolioBlogId)),
                    n => n.HasKey("PortfolioBlogId", "PortfolioBlogTagId")
                );
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(y => y.Book)
                .HasForeignKey(z => z.AuthorId)
                .IsRequired(true);
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Category)
                .WithMany(y => y.Book)
                .HasForeignKey(z => z.CategoryId)
                .IsRequired(true);
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Publisher)
                .WithMany(y => y.Book)
                .HasForeignKey(z => z.PublisherId)
                .IsRequired(true);
        }
    }
}
