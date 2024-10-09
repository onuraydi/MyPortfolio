namespace MyPortfolio.WebApi.Dtos.PortfolioBlogDtos
{
    public class CreatePortfolioBlogDto
    {
        public string Title { get; set; }
        public string SubContent { get; set; }
        public string Content { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
