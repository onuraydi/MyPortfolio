using MyPortfolio.WebApi.Dtos.ProjectImageDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Dtos.PortfolioProjectDtos
{
    public class GetPortfolioProjectByPortfolioProjectIdDto
    {
        public int PortfolioProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectRole { get; set; }
        public string Image { get; set; }  //CoverImage
        public string ProjectDescription { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectFinishDate { get; set; }
        public List<GetProjectImageByPortfolioProjectIdDto> projectImages { get; set; } = new List<GetProjectImageByPortfolioProjectIdDto>();
    }
}
