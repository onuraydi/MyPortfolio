namespace MyPortfolio.WebApi.Entites.LibraryEntities
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public List<Book> Book { get; set; }

        public Publisher() 
        {
            Book = new List<Book>();
        }

    }
}
