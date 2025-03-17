namespace MyPortfolio.WebApi.Entites
{
    public class BlogCategory
    {
        public int BlogCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<PortfolioBlog> PortfolioBlogs { get; set; } = [];
    }
}
