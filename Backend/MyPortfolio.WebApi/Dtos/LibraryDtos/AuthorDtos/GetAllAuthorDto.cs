using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;
using MyPortfolio.WebApi.Entites.LibraryEntities;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.AuthorDtos
{
    public class GetAllAuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public List<GetAllBookDto> Books { get; set; } = new List<GetAllBookDto>(); 
    }
}
