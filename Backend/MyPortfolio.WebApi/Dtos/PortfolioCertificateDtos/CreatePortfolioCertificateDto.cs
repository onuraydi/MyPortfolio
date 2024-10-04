namespace MyPortfolio.WebApi.Dtos.PortfolioCertificateDtos
{
    public class CreatePortfolioCertificateDto
    {
        public string CertificateName { get; set; }
        public string CertificateUrl { get; set; }
        public string CertificateDescription { get; set; }
        public DateTime CertificateDoneDate { get; set; }
    }
}
