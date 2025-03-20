using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;
using System.Reflection;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;
using Portfolio.WebUI.Models;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;
using Microsoft.AspNetCore.Authorization;
using Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioBlog")]
    [Authorize]
    public class PortfolioBlogController : Controller
    {
        private readonly IPortfolioBlogService _portfolioBlogService;
        private readonly IPortfolioBlogTagServices _portfolioBlogTagService;
        private readonly IBlogCategoryService _blogCategoryService;

        public PortfolioBlogController(IPortfolioBlogService portfolioBlogService, IPortfolioBlogTagServices portfolioBlogTagService, IBlogCategoryService blogCategoryService)
        {
            _portfolioBlogService = portfolioBlogService;
            _portfolioBlogTagService = portfolioBlogTagService;
            _blogCategoryService = blogCategoryService;
        }

        [HttpGet]
        [Route("GetAllPortfolioBlog")]
        public async Task<IActionResult> GetAllPortfolioBlog()
        {
            var values = await _portfolioBlogService.GetAllPortfolioBlogAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioBlog")]
        public async Task<IActionResult> CreatePortfolioBlog()
        {
            var tags = await _portfolioBlogTagService.GetAllPortfolioBlogTagAsync();
            var categories = await _blogCategoryService.GetAllPortfolioBlogCategoryAsync();
            var model = new BlogTagsViewModel
            {   
                BlogTags = tags,
                BlogCategories = categories,
                BlogCreate = new CreatePortfolioBlogDto()
            };
            return View(model);
        }

        [HttpPost]
        [Route("CreatePortfolioBlog")]
        public async Task<IActionResult> CreatePortfolioBlog([FromBody] CreatePortfolioBlogDto createPortfolioBlogDto)
        {
            try
            {
                if (createPortfolioBlogDto == null)
                {
                    return Json(new { success = false, message = "Blog verisi boş olamaz." });
                }

                // Blog'u oluştur
                var result = await _portfolioBlogService.CreatePortfolioBlogAsync(createPortfolioBlogDto);
                
                return Json(new { 
                    success = true, 
                    redirectToUrl = Url.Action("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" }) 
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog(int id)
        {
            var blog = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            var allTags = await _portfolioBlogTagService.GetAllPortfolioBlogTagAsync();
            var allCategories = await _blogCategoryService.GetAllPortfolioBlogCategoryAsync();

            var model = new BlogTagsViewModel
            {
                BlogTags = allTags,
                BlogCategories = allCategories,
                BlogUpdate = blog
            };

            return View(model);
        }

        [HttpPost]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog([FromBody] UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            try
            {
                await _portfolioBlogService.UpdatePortfolioBlogAsync(updatePortfolioBlogDto);
                
                return Json(new { 
                    success = true, 
                    redirectToUrl = Url.Action("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" }) 
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioBlog/{id}")]
        public async Task<IActionResult> DeletePortfolioBlog(int id)
        {
            await _portfolioBlogService.DeletePortfolioBlogAsync(id);
            return RedirectToAction("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" });
        }
    }
}
