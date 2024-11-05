namespace MyPortfolio.WebApi.Entites.LibraryEntities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Book> Book { get; set; }
        public Category() 
        {
            Book = new List<Book>();
        }
    }
}
