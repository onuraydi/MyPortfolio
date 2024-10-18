using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioTechnologyDtos
{
    public class UpdatePortfolioTechnologyDto
    {
        public int PortfolioTechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public string IconUrl { get; set; }
        public string Href { get; set; }
    }
}
