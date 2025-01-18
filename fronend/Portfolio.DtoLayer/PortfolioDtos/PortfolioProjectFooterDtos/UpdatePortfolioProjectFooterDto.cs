using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectFooterDtos
{
    public class UpdatePortfolioProjectFooterDto
    {
        public int PortfolioProjectFooterId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLink { get; set; }
    }
}
