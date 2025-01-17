using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos
{
    public class GetAllPortfolioBlogTagDto
    {
        public int PortfolioBlogTagId { get; set; }
        public string TagName { get; set; }

        public static implicit operator List<object>(GetAllPortfolioBlogTagDto v)
        {
            throw new NotImplementedException();
        }
    }
}
