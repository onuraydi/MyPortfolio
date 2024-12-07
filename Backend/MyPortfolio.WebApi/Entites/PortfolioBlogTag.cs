namespace MyPortfolio.WebApi.Entites
{
    public class PortfolioBlogTag
    {
        public int PortfolioBlogTagId { get; set; }
        public string TagName { get; set; }
        public List<PortfolioBlog> PortfolioBlogs { get; set; } = new();
    }
}
