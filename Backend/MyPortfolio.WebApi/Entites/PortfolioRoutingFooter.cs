namespace MyPortfolio.WebApi.Entites
{
    public class PortfolioRoutingFooter
    {
        public int PortfolioRoutingFooterId { get; set; }
        public string pageName { get; set; }
        public string pageHref { get; set; }  // section olarak da alınabilir ya da bloglar için direkt olarak kullanılabilir
    }
}
