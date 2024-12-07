using MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos;

namespace MyPortfolio.WebApi.Dtos.PortfolioBlogDtos
{
    public class GetPortfolioBlogByPortfolioBlogIdDto
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
