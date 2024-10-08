using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioCertificateDtos
{
    public class UpdatePortfolioCertificateDto
    {
        public int PortfolioCertificateId { get; set; }
        public string CertificateName { get; set; }
        public string CertificateUrl { get; set; }
        public string CertificateDescription { get; set; }
        public DateTime CertificateDoneDate { get; set; }
    }
}
