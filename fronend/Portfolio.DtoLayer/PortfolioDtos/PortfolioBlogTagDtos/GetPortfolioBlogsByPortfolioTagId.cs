using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos
{
    public class GetPortfolioBlogsByPortfolioTagId
    {
        public int PortfolioBlogTagId { get; set; }
        public string TagName { get; set; }
        public List<GetPortfolioBlogsByPortfolioBlogTagsIdDto> PortfolioBlogs { get; set; } = new List<GetPortfolioBlogsByPortfolioBlogTagsIdDto>();
    }
}
