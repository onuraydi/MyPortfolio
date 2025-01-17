using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;

namespace Portfolio.WebUI.Models
{
    public class BlogTagsViewModel
    {
        public List<GetAllPortfolioBlogTagDto> BlogTags { get; set; }
        public CreatePortfolioBlogDto BlogCreate { get; set; }
        //public List<GetAllPortfolioBlogDto> getAllPortfolioBlogDtos { get; set; }
    }
}
