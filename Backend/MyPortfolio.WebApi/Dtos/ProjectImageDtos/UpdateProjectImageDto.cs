namespace MyPortfolio.WebApi.Dtos.ProjectImageDtos
{
    public class UpdateProjectImageDto
    {
        public int ProjectImageId { get; set; }
        public string Image { get; set; }
        public int PortfolioProjectId { get; set; }
    }
}
