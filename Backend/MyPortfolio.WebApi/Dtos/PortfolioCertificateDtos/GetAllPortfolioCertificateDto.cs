namespace MyPortfolio.WebApi.Dtos.PortfolioCertificateDtos
{
    public class GetAllPortfolioCertificateDto
    {
        public int PortfolioCertificateId { get; set; }
        public string CertificateName { get; set; }
        public string CertificateUrl { get; set; }
        public string CertificateDescription { get; set; }
        public DateTime CertificateDoneDate { get; set; }
        public string Image { get; set; }
    }
}
