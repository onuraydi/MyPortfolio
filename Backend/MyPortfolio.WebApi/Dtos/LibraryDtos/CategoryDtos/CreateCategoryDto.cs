using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public List<CreateBookDto> Books { get; set; } = new List<CreateBookDto>();
    }
}
