using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.CategoryDtos
{
    public class UpdateCategroyDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<UpdateBookDto> Books { get; set; } = new List<UpdateBookDto>();
    }
}
