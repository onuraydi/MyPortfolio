using Portfolio.DtoLayer.PortfolioDtos.BlogCategoryDtos;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos
{
    public class GetPortfolioBlogTagsByPortfolioBlogIdDto
    {
        public int PortfolioBlogId { get; set; }

        public List<GetAllPortfolioBlogTagDto> PortfolioBlogTags { get; set; } = new List<GetAllPortfolioBlogTagDto>();
        public List<GetBlogCategoryDto> PortfolioBlogCategories { get; set; } = new List<GetBlogCategoryDto>();
    }
}
