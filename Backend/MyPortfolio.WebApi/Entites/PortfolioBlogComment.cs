namespace MyPortfolio.WebApi.Entites
{
    public class PortfolioBlogComment
    {
        public int PortfolioBlogCommentId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDetail { get; set; }
        public double CommentRate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }  // ilerde user olarak alınabilir
        
    }
}
