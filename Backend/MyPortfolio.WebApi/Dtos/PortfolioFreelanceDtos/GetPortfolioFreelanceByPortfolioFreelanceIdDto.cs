namespace MyPortfolio.WebApi.Dtos.PortfolioFreelanceDtos
{
    public class GetPortfolioFreelanceByPortfolioFreelanceIdDto
    {
        public int PortfolioFreelanceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonHref { get; set; }
    }
}
