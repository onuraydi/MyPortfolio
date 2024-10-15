using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioAboutMeDtos
{
    public class UpdatePortfolioAboutMeDto
    {
        public int PortfolioAboutMeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string NameSurname { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ButtonName { get; set; }
        public string ButtonHref { get; set; }
    }
}
