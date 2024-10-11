namespace MyPortfolio.WebApi.Dtos.PortfolioContactDtos
{
    public class GetPortfolioContactByPortfolioContactDto
    {
        public int PortfolioContactId { get; set; }
        public string SenderNameSurname { get; set; }
        public string SenderEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetail { get; set; }
        public bool isRead { get; set; }
    }
}
