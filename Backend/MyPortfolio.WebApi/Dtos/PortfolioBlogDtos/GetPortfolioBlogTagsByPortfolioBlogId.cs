using MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Dtos.PortfolioBlogDtos
{
    public class GetPortfolioBlogTagsByPortfolioBlogId
    {
        public int PortfolioBlogId { get; set; }
        public List<GetAllPortfolioBlogTagDto> PortfolioBlogTags { get; set; } = new List<GetAllPortfolioBlogTagDto>();
    }
}
