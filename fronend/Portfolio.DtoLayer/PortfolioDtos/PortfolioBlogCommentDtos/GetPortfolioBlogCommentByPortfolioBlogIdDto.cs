using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogCommentDtos
{
    public class GetPortfolioBlogCommentByPortfolioBlogIdDto
    {
        public DateTime CommentDate { get; set; }
        public int PortfolioBlogCommentId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDetail { get; set; }
        public string email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }  // ilerde user olarak alınabilir
        public int portfolioBlogId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
