using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.CategoryDtos
{
    public class GetAllCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<GetAllBookDto> Books { get; set; } = new List<GetAllBookDto>();
    }
}
