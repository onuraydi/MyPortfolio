using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos
{
    public class GetAllPortfolioBlogDto
    {
        public int PortfolioBlogId { get; set; }
        public string Title { get; set; }
        public string SubContent { get; set; }
        public string Content { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishDate { get; set; }
        public List<GetAllPortfolioBlogTagDto> PortfolioBlogTags { get; set; } = new List<GetAllPortfolioBlogTagDto>();
    }
}
