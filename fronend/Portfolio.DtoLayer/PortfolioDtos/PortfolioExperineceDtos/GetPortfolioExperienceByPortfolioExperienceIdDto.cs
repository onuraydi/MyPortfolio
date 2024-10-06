using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioExperineceDtos
{
    public class GetPortfolioExperienceByPortfolioExperienceIdDto
    {
        public int PortfolioExperienceId { get; set; }
        public string ExperienceTitle { get; set; }
        public string CompanyName { get; set; }
        public string ExperienceDate { get; set; }
        public string Description { get; set; }
    }
}
