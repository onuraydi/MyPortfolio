using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos
{
    public class GetPortfolioBlogCommentByPortfolioBlogIdDto
    {
        public int PortfolioBlogCommentId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDetail { get; set; }
        public double CommentRate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }  // ilerde user olarak alınabilir
        public int portfolioBlogId { get; set; }
    }
}
