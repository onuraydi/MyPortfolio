using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioProjectDtos
{
    public class UpdatePortfolioProjectDto
    {
        public int PortfolioProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectRole { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Image6 { get; set; }
        public string? Image7 { get; set; }
        public string? Image8 { get; set; }
        public string? Image9 { get; set; }
        public string? Image10 { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectStartDate { get; set; }
    }
}
