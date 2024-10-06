using AutoMapper;
using MyPortfolio.WebApi.Dtos.PortfolioAboutMeDtos;
using MyPortfolio.WebApi.Dtos.PortfolioCertificateDtos;
using MyPortfolio.WebApi.Dtos.PortfolioEducationDtos;
using MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos;
using MyPortfolio.WebApi.Dtos.PortfolioMainTitleDtos;
using MyPortfolio.WebApi.Dtos.PortfolioProjectDtos;
using MyPortfolio.WebApi.Dtos.PortfolioSkillDtos;
using MyPortfolio.WebApi.Dtos.PortfolioTechnologyDtos;
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
            CreateMap<PortfolioMainTitle, GetPortfolioMainTitleByPortfolioMainTitleIdDto>().ReverseMap();

            // About Me 
            CreateMap<PortfolioAboutMe, GetPortfolioAboutMeDto>().ReverseMap();
            CreateMap<PortfolioAboutMe, UpdatePortfolioAboutMeDto>().ReverseMap();
            CreateMap<PortfolioAboutMe, GetPortfolioAboutMeByPortfolioAboutMeIdDto>().ReverseMap();

            // Experience
            CreateMap<PortfolioExperience, GetAllPortfolioExperienceDto>().ReverseMap();
            CreateMap<PortfolioExperience, CreatePortfolioExperienceDto>().ReverseMap();
            CreateMap<PortfolioExperience, UpdatePortfolioExperienceDto>().ReverseMap();
            CreateMap<PortfolioExperience, GetPortfolioExperienceByPortfolioExperienceIdDto>().ReverseMap();

            // Skill
            CreateMap<PortfolioSkill, GetAllPortfolioSkillDto>().ReverseMap();
            CreateMap<PortfolioSkill, CreatePortfolioSkillDto>().ReverseMap();
            CreateMap<PortfolioSkill, UpdatePortfolioSkillDto>().ReverseMap();
            CreateMap<PortfolioSkill, GetPortfolioSkillBySkillIdDto>().ReverseMap();

            // Certificate
            CreateMap<PortfolioCertificate, GetAllPortfolioCertificateDto>().ReverseMap();
            CreateMap<PortfolioCertificate, CreatePortfolioCertificateDto>().ReverseMap();
            CreateMap<PortfolioCertificate, UpdatePortfolioCertificateDto>().ReverseMap();
            CreateMap<PortfolioCertificate, GetPortfolioCertificateByPortfolioCertificateIdDto>().ReverseMap();

            // Education
            CreateMap<PortfolioEducation, GetAllPortfolioEducationDto>().ReverseMap();
            CreateMap<PortfolioEducation, CreatePortfolioEducationDto>().ReverseMap();
            CreateMap<PortfolioEducation, UpdatePortfolioEducationDto>().ReverseMap();
            CreateMap<PortfolioEducation, GetPortfolioEducationByPortfolioEducationId>().ReverseMap();

            // Project
            CreateMap<PortfolioProject, GetAllPortfolioProjectDto>().ReverseMap();
            CreateMap<PortfolioProject, CreatePortfolioProjectDto>().ReverseMap();
            CreateMap<PortfolioProject, UpdatePortfolioProjectDto>().ReverseMap();
            CreateMap<PortfolioProject, GetPortfolioProjectByPortfolioProjectIdDto>().ReverseMap();

            // Technology
            CreateMap<PortfolioTechnology, GetAllPortfolioTechnologyDto>().ReverseMap();
            CreateMap<PortfolioTechnology, CreatePortfolioTechnologyDto>().ReverseMap();
            CreateMap<PortfolioTechnology, UpdatePortfolioTechnologyDto>().ReverseMap();
            CreateMap<PortfolioTechnology, GetPortfolioTechnologyByPortfolioTechnologyIdDto>().ReverseMap();
        }
    }
}
