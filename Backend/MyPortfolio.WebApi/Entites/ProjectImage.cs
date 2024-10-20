namespace MyPortfolio.WebApi.Entites
{
    public class ProjectImage
    {
        public int ProjectImageId { get; set; }
        public string Image { get; set; }
        public PortfolioProject PortfolioProject { get; set; }
        public int PortfolioProjectId { get; set; }
    }
}
