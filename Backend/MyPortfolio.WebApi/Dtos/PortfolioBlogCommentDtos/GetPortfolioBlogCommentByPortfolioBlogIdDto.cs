using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos
{
    public class GetPortfolioBlogCommentByPortfolioBlogIdDto
    {
        public int PortfolioBlogCommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDetail { get; set; }
        public string email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }  // ilerde user olarak alınabilir
        public int portfolioBlogId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
