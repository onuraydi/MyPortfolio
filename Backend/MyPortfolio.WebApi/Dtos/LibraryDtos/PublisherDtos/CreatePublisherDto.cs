using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.PublisherDtos
{
    public class CreatePublisherDto
    {
        public string PublisherName { get; set; }
        public List<CreateBookDto> Books { get; set; } = new List<CreateBookDto>();
    }
}
