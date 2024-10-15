namespace MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos
{
    public class CreatePortfolioExperienceDto
    {
        public string ExperienceTitle { get; set; }
        public string CompanyName { get; set; }
        public string ExperienceDate { get; set; }
        public string Description { get; set; }
        public string ButtonName { get; set; }
        public string ButtonHref { get; set; }
        public string PartTitle { get; set; }
        public string PartDescription { get; set; }
    }
}
