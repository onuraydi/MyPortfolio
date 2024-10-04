namespace MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos
{
    public class GetAllPortfolioExperienceDto
    {
        public int PortfolioExperienceId { get; set; }
        public string ExperienceTitle { get; set; }
        public string CompanyName { get; set; }
        public string ExperienceDate { get; set; }
        public string Description { get; set; }
    }
}
