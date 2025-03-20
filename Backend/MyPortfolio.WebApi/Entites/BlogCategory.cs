namespace MyPortfolio.WebApi.Entites
{
    public class BlogCategory
    {
        public int BlogCategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<PortfolioBlog> PortfolioBlogs { get; set; } = new List<PortfolioBlog>();
    }
}
