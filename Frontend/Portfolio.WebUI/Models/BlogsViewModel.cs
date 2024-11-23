using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogCommentDtos;

namespace Portfolio.WebUI.Models
{
    public class BlogsViewModel
    {
        public List<GetPortfolioBlogCommentByPortfolioBlogIdDto> BlogComments { get; set; }
        public CreatePortfolioBlogCommentDto CreateComment { get; set; }
    }
}
