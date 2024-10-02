using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Context
{
    public class PortfolioContext:DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options):base(options) { }

        public DbSet<PortfolioMainTitle> PortfolioMainTitles { get; set; }
        public DbSet<PortfolioAboutMe> portfolioAboutMe { get; set; }
    }
}
