using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioSkillDtos
{
    public class GetPortfolioSkillByPortfolioSkillIdDto
    {
        public int PortfolioSkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillPercent { get; set; }
    }
}
