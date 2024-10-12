using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioMainTitleDtos
{
    public class UpdatePortfolioMainTitleDto
    {
        public int PortfolioMainTitleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ButtonName1 { get; set; }
        public string ButtonName2 { get; set; }
        public string Button1Href { get; set; }
        public string Button2Href { get; set; }
    }
}
