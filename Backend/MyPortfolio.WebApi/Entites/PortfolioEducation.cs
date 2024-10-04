namespace MyPortfolio.WebApi.Entites
{
    public class PortfolioEducation
    {
        public int PortfolioEducationId { get; set; }
        public string SchoolName { get; set; }
        public string EducationDetail { get; set; }
        public string EducationDate { get; set; }
        public double Average { get; set; }
        public string EducationDescription { get; set; }  // kazanımlar gibi bir metin
    }
}
