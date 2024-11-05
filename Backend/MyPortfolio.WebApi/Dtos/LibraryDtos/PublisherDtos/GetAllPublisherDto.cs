using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.PublisherDtos
{
    public class GetAllPublisherDto
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public List<GetAllBookDto> Books { get; set; } = new List<GetAllBookDto>();
    }
}
