using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectFooterDtos
{
    public class GetPortfollioProjectFooterByPortfolioProjectFooterIdDto
    {
        public int PortfolioProjectFooterId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLink { get; set; }
    }
}
