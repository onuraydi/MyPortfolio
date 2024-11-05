namespace MyPortfolio.WebApi.Entites.LibraryEntities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string BookImage { get; set; }
        public string status { get; set; }  // okundu okunmadı tekrar
        public string BookLink { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

    }
}
