using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.PublisherDtos
{
    public class UpdatePublisherDto
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public List<UpdateBookDto> Books { get; set; } = new List<UpdateBookDto>();
    }
}
