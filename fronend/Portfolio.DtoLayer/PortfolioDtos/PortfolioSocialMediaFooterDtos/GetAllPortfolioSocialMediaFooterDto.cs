using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioSocialMediaFooterDtos
{
    public class GetAllPortfolioSocialMediaFooterDto
    {
        public int PortfolioSocialMediaFooterId { get; set; }
        public string FooterName { get; set; }
        public string FooterLink { get; set; }
        public string FooterIcon { get; set; }
    }
}
