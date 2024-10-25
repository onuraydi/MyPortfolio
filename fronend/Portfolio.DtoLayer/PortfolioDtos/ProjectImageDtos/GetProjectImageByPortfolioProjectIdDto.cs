using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.ProjectImageDtos
{
    public class GetProjectImageByPortfolioProjectIdDto
    {
        public int ProjectImageId { get; set; }
        public string Image { get; set; }
        public int PortfolioProjectId { get; set; }
    }
}
