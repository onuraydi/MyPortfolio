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

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioBlog")]
    [Authorize]
    public class PortfolioBlogController : Controller
    {
        private readonly IPortfolioBlogService _portfolioBlogService;
        private readonly IPortfolioBlogTagServices _portfolioBlogTagService;

        public PortfolioBlogController(IPortfolioBlogService portfolioBlogService, IPortfolioBlogTagServices portfolioBlogTagService)
        {
            _portfolioBlogService = portfolioBlogService;
            _portfolioBlogTagService = portfolioBlogTagService;
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
            var values = await _portfolioBlogTagService.GetAllPortfolioBlogTagAsync();
            return View(values);
        }



        [HttpPost]
        [Route("CreatePortfolioBlog")]
        public async Task<IActionResult> CreatePortfolioBlog(CreatePortfolioBlogDto createPortfolioBlogDto, List<GetAllPortfolioBlogTagDto> getAllPortfolioBlogTagDto)
        {
            var tagModel = new BlogTagsViewModel()
            {
                BlogCreate = createPortfolioBlogDto,
                BlogTags = getAllPortfolioBlogTagDto
            };

            var values = await _portfolioBlogService.CreatePortfolioBlogAsync(tagModel.BlogCreate);

            values.PortfolioBlogTags.AddRange(tagModel.BlogTags);

            return Json(new { redirectToUrl = Url.Action("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" }) });
        }


        [HttpGet]
        [Route("AddTagPortfolioBlog/{id}")]
        public async Task<IActionResult> AddTagPortfolioBlog(int id)
        {
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("AddTagPortfolioBlog/{id}")]
        public async Task<IActionResult> AddTagPortfolioBlog(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            await _portfolioBlogService.UpdatePortfolioBlogAsync(updatePortfolioBlogDto);
            return RedirectToAction("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" });
        }



        [HttpGet]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog(int id)
        {
            var values = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);

            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog(UpdatePortfolioBlogDto updatePortfolioBlogDto)
        {
            await _portfolioBlogService.UpdatePortfolioBlogAsync(updatePortfolioBlogDto);
            return RedirectToAction("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" });
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
