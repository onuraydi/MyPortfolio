using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioContactDtos
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
