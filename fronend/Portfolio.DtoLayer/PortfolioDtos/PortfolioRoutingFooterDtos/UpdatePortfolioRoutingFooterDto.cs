using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioRoutingFooterDtos
{
    public class UpdatePortfolioRoutingFooterDto
    {
        public int PortfolioRoutingFooterId { get; set; }
        public string pageName { get; set; }
        public string pageHref { get; set; }
    }
}
