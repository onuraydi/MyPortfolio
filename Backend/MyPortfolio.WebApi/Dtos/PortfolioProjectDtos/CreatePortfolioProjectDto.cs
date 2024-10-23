using MyPortfolio.WebApi.Dtos.ProjectImageDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Dtos.PortfolioProjectDtos
{
    public class CreatePortfolioProjectDto
    {
        public string ProjectName { get; set; }
        public string ProjectRole { get; set; }
        public string Image { get; set; }  //CoverImage
        public string ProjectDescription { get; set; }
        public string ProjectStartDate { get; set; }
        public List<CreateProjectImageDto> projectImages { get; set; } = new List<CreateProjectImageDto>();
    }
}
