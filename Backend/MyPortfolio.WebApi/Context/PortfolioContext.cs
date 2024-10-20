using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Entites;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioProject>()
                .HasMany(x => x.Images)
                .WithOne(y => y.PortfolioProject)
                .HasForeignKey(z => z.PortfolioProjectId)
                .IsRequired(true);
        }
    }
}
