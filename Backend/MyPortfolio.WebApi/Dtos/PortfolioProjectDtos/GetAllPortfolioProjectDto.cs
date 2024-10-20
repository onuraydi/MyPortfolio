namespace MyPortfolio.WebApi.Dtos.PortfolioProjectDtos
{
    public class GetAllPortfolioProjectDto
    {
        public int PortfolioProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectRole { get; set; }
        public string Image { get; set; }  //CoverImage
        public string ProjectDescription { get; set; }
        public string ProjectStartDate { get; set; }
    }
}
