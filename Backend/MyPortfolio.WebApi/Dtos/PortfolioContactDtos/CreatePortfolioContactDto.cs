namespace MyPortfolio.WebApi.Dtos.PortfolioContactDtos
{
    public class CreatePortfolioContactDto
    {
        public string SenderNameSurname { get; set; }
        public string SenderEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetail { get; set; }
        public bool isRead { get; set; }
    }
}
