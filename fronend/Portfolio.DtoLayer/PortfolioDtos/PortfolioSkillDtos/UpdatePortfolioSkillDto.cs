using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioSkillDtos
{
    public class UpdatePortfolioSkillDto
    {
        public int PortfolioSkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillPercent { get; set; }
    }
}
