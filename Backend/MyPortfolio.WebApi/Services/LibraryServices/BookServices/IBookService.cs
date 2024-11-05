using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;

namespace MyPortfolio.WebApi.Services.LibraryServices.BookServices
{
    public interface IBookService
    {
        Task<List<GetAllBookDto>> GetAllBookAsync();
        Task CreateBookAsync(CreateBookDto createBookDto);
        Task UpdateBookAsync(UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int id);
        Task<GetBookByBookIdDto> GetBookByBookIdAsync(int id);
    }
}
