using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;
using MyPortfolio.WebApi.Entites.LibraryEntities;

namespace MyPortfolio.WebApi.Services.LibraryServices.BookServices
{
    public class BookService : IBookService
    {
        private readonly PortfolioContext _context;
        private readonly IMapper _mapper;

        public BookService(PortfolioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateBookAsync(CreateBookDto createBookDto)
        {
            var values = _mapper.Map<Book>(createBookDto);
            await _context.AddAsync(values);
            _context.SaveChanges();
        }

        public async Task DeleteBookAsync(int id)
        {
            var values = await _context.Books.FindAsync(id);
            _context.Books.Remove(values);
            _context.SaveChanges();
        }

        public async Task<List<GetAllBookDto>> GetAllBookAsync()
        {
            var values = await _context.Books.ToListAsync();
            return _mapper.Map<List<GetAllBookDto>>(values);
        }

        public async Task<GetBookByBookIdDto> GetBookByBookIdAsync(int id)
        {
            var values = await _context.Books.FindAsync(id);
            return _mapper.Map<GetBookByBookIdDto>(values);
        }

        public async Task UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var values = _mapper.Map<Book>(updateBookDto);
            _context.Books.Update(values);
            _context.SaveChanges();
        }
    }
}
