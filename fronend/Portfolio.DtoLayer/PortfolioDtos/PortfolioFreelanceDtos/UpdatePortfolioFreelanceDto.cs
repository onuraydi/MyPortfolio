using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioFreelanceDtos
{
    public class UpdatePortfolioFreelanceDto
    {
        public int PortfolioFreelanceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonHref { get; set; }
    }
}
