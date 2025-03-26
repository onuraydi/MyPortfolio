using Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectDtos
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
        public string ProjectHref { get; set; }
        public List<GetProjectImageByPortfolioProjectIdDto> projectImages { get; set; } = new List<GetProjectImageByPortfolioProjectIdDto>();
    }
}
