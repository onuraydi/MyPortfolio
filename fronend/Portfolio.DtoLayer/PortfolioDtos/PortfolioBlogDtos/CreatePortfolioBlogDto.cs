using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos
{
    public class CreatePortfolioBlogDto
    {
        public string Title { get; set; }
        public string SubContent { get; set; }
        public string Content { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishDate { get; set; }
        public List<int> TagIds { get; set; } = new List<int>();
        public List<int> CategoryIds { get; set; } = new List<int>();
        //public List<GetAllPortfolioBlogTagDto> PortfolioBlogTags { get; set; } = new List<GetAllPortfolioBlogTagDto>();
    }
}
