using AutoMapper;
using MyPortfolio.WebApi.Dtos.LibraryDtos.AuthorDtos;
using MyPortfolio.WebApi.Dtos.LibraryDtos.BookDtos;
using MyPortfolio.WebApi.Dtos.LibraryDtos.CategoryDtos;
using MyPortfolio.WebApi.Dtos.LibraryDtos.PublisherDtos;
using MyPortfolio.WebApi.Dtos.PortfolioAboutMeDtos;
using MyPortfolio.WebApi.Dtos.PortfolioBlogCommentDtos;
using MyPortfolio.WebApi.Dtos.PortfolioBlogDtos;
using MyPortfolio.WebApi.Dtos.PortfolioBlogTagDtos;
using MyPortfolio.WebApi.Dtos.PortfolioCertificateDtos;
using MyPortfolio.WebApi.Dtos.PortfolioContactDtos;
using MyPortfolio.WebApi.Dtos.PortfolioEducationDtos;
using MyPortfolio.WebApi.Dtos.PortfolioExperienceDtos;
using MyPortfolio.WebApi.Dtos.PortfolioMainTitleDtos;
using MyPortfolio.WebApi.Dtos.PortfolioProjectDtos;
using MyPortfolio.WebApi.Dtos.PortfolioSkillDtos;
using MyPortfolio.WebApi.Dtos.PortfolioSocialMediaFooter;
using MyPortfolio.WebApi.Dtos.PortfolioTechnologyDtos;
using MyPortfolio.WebApi.Dtos.ProjectImageDtos;
using MyPortfolio.WebApi.Entites;
using MyPortfolio.WebApi.Entites.LibraryEntities;

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
            CreateMap<PortfolioProject, GetAllPortfolioProjectDto>().ForMember(x => x.projectImages, opt => opt.MapFrom(src => src.Images)).ReverseMap();
            CreateMap<PortfolioProject, CreatePortfolioProjectDto>().ForMember(x => x.projectImages, opt => opt.MapFrom(src => src.Images)).ReverseMap();
            CreateMap<PortfolioProject, UpdatePortfolioProjectDto>().ForMember(x => x.projectImages, opt => opt.MapFrom(src => src.Images)).ReverseMap();
            CreateMap<PortfolioProject, GetPortfolioProjectByPortfolioProjectIdDto>().ForMember(x => x.projectImages, opt => opt.MapFrom(src => src.Images)).ReverseMap();

            //BlogTag
            CreateMap<PortfolioBlogTag, GetAllPortfolioBlogTagDto>().ReverseMap();
            CreateMap<PortfolioBlogTag, CreatePortfolioBlogTagDto>().ForMember(x => x.TagName, opt => opt.MapFrom(src => src.TagName)).ReverseMap();
            CreateMap<PortfolioBlogTag, UpdatePortfolioBlogTagDto>().ForMember(x => x.TagName, opt => opt.MapFrom(src => src.TagName)).ReverseMap();

            CreateMap<PortfolioBlog, GetPortfolioBlogTagsByPortfolioBlogId>()
                       .ForMember(dest => dest.PortfolioBlogId, opt => opt.MapFrom(src => src.PortfolioBlogId))
                       .ForMember(dest => dest.PortfolioBlogTags, opt => opt.MapFrom(src => src.PortfolioBlogTags));


            CreateMap<PortfolioBlogTag, GetPortfolioBlogTagByPortfolioBlogTagId>().ForMember(x => x.TagName, opt => opt.MapFrom(src => src.TagName)).ReverseMap();
            //CreateMap<PortfolioBlogTag, GetPortfolioBlogsByPortfolioBlogTagsIdDto>().ForMember(x => x.PortfolioBlogTags, opt => opt.MapFrom(src => src.PortfolioBlogs)).ReverseMap();
            CreateMap<PortfolioBlog, GetPortfolioBlogsByPortfolioBlogTagsIdDto>().ForMember(dto => dto.PortfolioBlogTags,opt => opt.MapFrom(src => src.PortfolioBlogTags)).ReverseMap();




            // Technology
            CreateMap<PortfolioTechnology, GetAllPortfolioTechnologyDto>().ReverseMap();
            CreateMap<PortfolioTechnology, CreatePortfolioTechnologyDto>().ReverseMap();
            CreateMap<PortfolioTechnology, UpdatePortfolioTechnologyDto>().ReverseMap();
            CreateMap<PortfolioTechnology, GetPortfolioTechnologyByPortfolioTechnologyIdDto>().ReverseMap();

            // Blog
            CreateMap<PortfolioBlog, GetAllPortfolioBlogDto>().ReverseMap();
            CreateMap<PortfolioBlog, CreatePortfolioBlogDto>().ReverseMap();
            CreateMap<PortfolioBlog, UpdatePortfolioBlogDto>().ReverseMap();
            CreateMap<PortfolioBlog, GetPortfolioBlogByPortfolioBlogIdDto>().ReverseMap();
            CreateMap<PortfolioBlog, GetPortfolioBlogsByPortfolioBlogTagsIdDto>().ReverseMap();

            // Contact
            CreateMap<PortfolioContact, GetAllPortfolioContactDto>().ReverseMap();
            CreateMap<PortfolioContact, CreatePortfolioContactDto>().ReverseMap();
            CreateMap<PortfolioContact, UpdatePortfolioContactDto>().ReverseMap();
            CreateMap<PortfolioContact, GetPortfolioContactByPortfolioContactDto>().ReverseMap();

            // Blog Comment
            CreateMap<PortfolioBlogComment, GetAllPortfolioBlogCommentDto>().ReverseMap();
            CreateMap<PortfolioBlogComment, CreatePortfolioBlogCommentDto>().ReverseMap();
            CreateMap<PortfolioBlogComment, GetPortfolioBlogCommentByPortfolioBlogCommentIdDto>().ReverseMap();
            CreateMap<PortfolioBlogComment, GetPortfolioBlogCommentByPortfolioBlogIdDto>().ReverseMap();

            // Project Image
            CreateMap<ProjectImage, GetProjectImageByPortfolioProjectIdDto>().ReverseMap();
            CreateMap<ProjectImage, CreateProjectImageDto>().ReverseMap();
            CreateMap<ProjectImage, UpdateProjectImageDto>().ReverseMap();

            // Social Media Footer
            CreateMap<PortfolioSocialMediaFooter, GetAllPortfolioSocialMediaFooterDto>().ReverseMap();
            CreateMap<PortfolioSocialMediaFooter, CreatePortfolioSocialMediaFooterDto>().ReverseMap();
            CreateMap<PortfolioSocialMediaFooter, UpdatePortfolioSocialMediaFooterDto>().ReverseMap();
            CreateMap<PortfolioSocialMediaFooter, GetPortfolioSocialMediaFooterByIdDto>().ReverseMap();

            // Library parts
            //Book
            CreateMap<Book, GetAllBookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Book, GetBookByBookIdDto>().ReverseMap();

            // Category
            CreateMap<Category, GetAllCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategroyDto>().ReverseMap();
            CreateMap<Category, GetCategoryByCategoryIdDto>().ReverseMap();

            // Author
            CreateMap<Author, GetAllAuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            CreateMap<Author, GetAuthorByAuthorIdDto>().ReverseMap();

            // Publisher
            CreateMap<Publisher, GetAllPublisherDto>().ReverseMap();
            CreateMap<Publisher, CreatePublisherDto>().ReverseMap();
            CreateMap<Publisher, UpdatePublisherDto>().ReverseMap();
            CreateMap<Publisher, GetPublisherByPublisherIdDto>().ReverseMap();

        }
    }
}
