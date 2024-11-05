using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.PublisherDtos
{
    public class GetPublisherByPublisherIdDto
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public List<GetBookByBookIdDto> Books { get; set; } = new List<GetBookByBookIdDto>();
    }
}
