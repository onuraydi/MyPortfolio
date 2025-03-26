namespace MyPortfolio.WebApi.Entites
{
    public class PortfolioBlog
    {
        public int PortfolioBlogId { get; set; }
        public string Title { get; set; }
        public string SubContent { get; set; }
        public string Content { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishDate { get; set; }
        public bool isSuggested { get; set; }
        public virtual ICollection<PortfolioBlogTag> PortfolioBlogTags { get; set; } = new List<PortfolioBlogTag>();

        public virtual ICollection<BlogCategory> PortfolioBlogCategories { get; set; } = new List<BlogCategory>();

        //public PortfolioBlogComment portfolioBlogComment { get; set; }

    }
}
