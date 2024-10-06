using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioAboutMeDtos
{
    public class GetPortfolioAboutMeByPortfolioAboutMeIdDto
    {
        public int PortfolioAboutMeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
