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
    }
}
