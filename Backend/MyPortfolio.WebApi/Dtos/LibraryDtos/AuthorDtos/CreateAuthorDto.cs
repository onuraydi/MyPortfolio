using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.AuthorDtos
{
    public class CreateAuthorDto
    {
        public string AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public List<CreateBookDto> Books { get; set; } = new List<CreateBookDto>();
    }
}
