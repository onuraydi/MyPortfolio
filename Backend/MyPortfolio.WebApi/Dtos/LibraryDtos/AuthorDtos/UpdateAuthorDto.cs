using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public List<UpdateBookDto> Books { get; set; } = new List<UpdateBookDto>();
    }
}
