using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioEducationDtos
{
    public class UpdatePortfolioEducationDto
    {
        public int PortfolioEducationId { get; set; }
        public string SchoolName { get; set; }
        public string EducationDetail { get; set; }
        public string EducationDate { get; set; }
        public double Average { get; set; }
        public string EducationDescription { get; set; }
    }
}
