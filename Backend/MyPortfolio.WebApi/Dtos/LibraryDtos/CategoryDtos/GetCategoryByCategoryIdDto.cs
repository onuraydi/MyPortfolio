using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.CategoryDtos
{
    public class GetCategoryByCategoryIdDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<GetBookByBookIdDto> Books { get; set; } = new List<GetBookByBookIdDto>();
    }
}
