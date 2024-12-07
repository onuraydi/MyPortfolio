using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos
{
    public class GetPortfolioBlogsByPortfolioTagId
    {
        public int PortfolioBlogTagId { get; set; }
        public string TagName { get; set; }
        public List<GetPortfolioBlogsByPortfolioBlogTagsIdDto> PortfolioBlogs { get; set; } = new List<GetPortfolioBlogsByPortfolioBlogTagsIdDto>();
    }
}
