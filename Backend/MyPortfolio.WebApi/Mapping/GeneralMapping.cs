using AutoMapper;
using MyPortfolio.WebApi.Dtos.PortfolioAboutMeDtos;
using MyPortfolio.WebApi.Dtos.PortfolioMainTitleDtos;
using MyPortfolio.WebApi.Entites;

namespace MyPortfolio.WebApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            // Main Title 
            CreateMap<PortfolioMainTitle, GetPortfolioMainTitleDto>().ReverseMap();
            CreateMap<PortfolioMainTitle, UpdatePortfoiloMainTitleDto>().ReverseMap();

            // About Me 
            CreateMap<PortfolioAboutMe, GetPortfolioAboutMeDto>().ReverseMap();
            CreateMap<PortfolioAboutMe, UpdatePortfolioAboutMeDto>().ReverseMap();
        }
    }
}
