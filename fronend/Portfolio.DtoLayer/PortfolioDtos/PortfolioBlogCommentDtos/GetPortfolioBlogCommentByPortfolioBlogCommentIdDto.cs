using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogCommentDtos
{
    public class GetPortfolioBlogCommentByPortfolioBlogCommentIdDto
    {
        public int PortfolioBlogCommentId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDetail { get; set; }
        public double CommentRate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
