﻿
namespace MyPortfolio.WebApi.Entites
{
    public class PortfolioBlog
    {
        public int PortfolioBlogId { get; set; }
        public string Title { get; set; }
        public string SubContent { get; set; }
        public string Content { get; set; }
        public string CoverImage { get; set; }
        public DateTime PublishDate { get; set; }

        public List<PortfolioBlogTag> PortfolioBlogTags { get; set; } = new();

        //public PortfolioBlogComment portfolioBlogComment { get; set; }

    }
}
