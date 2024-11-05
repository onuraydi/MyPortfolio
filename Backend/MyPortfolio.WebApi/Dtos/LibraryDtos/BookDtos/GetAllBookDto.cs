using MyPortfolio.WebApi.Dtos.LibraryDtos.AuthorDtos;
using MyPortfolio.WebApi.Dtos.LibraryDtos.CategoryDtos;
using MyPortfolio.WebApi.Dtos.LibraryDtos.PublisherDtos;
using MyPortfolio.WebApi.Entites.LibraryEntities;

namespace MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos
{
    public class GetAllBookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string BookImage { get; set; }
        public string status { get; set; }  // okundu okunmadı tekrar
        public string BookLink { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
    }
}
