namespace MyPortfolio.WebApi.Entites
{
    public class PortfolioBlogTag
    {
        public int PortfolioBlogTagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<PortfolioBlog> PortfolioBlogs { get; set; } = new List<PortfolioBlog>();
    }
}