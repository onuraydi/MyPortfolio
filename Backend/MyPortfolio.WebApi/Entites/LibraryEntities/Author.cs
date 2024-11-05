namespace MyPortfolio.WebApi.Entites.LibraryEntities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string? AuthorSurname { get; set; }
        public List<Book> Book { get; set; }

        public Author() 
        {
            Book = new List<Book>();
        }
    }
}
