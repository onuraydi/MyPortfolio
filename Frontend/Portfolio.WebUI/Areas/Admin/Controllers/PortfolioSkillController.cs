using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioSkillDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSkillServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioSkill")]
    public class PortfolioSkillController : AdminBaseController
    {
        private readonly IPortfolioSkillService _portfolioSkillService;

        public PortfolioSkillController(IPortfolioSkillService portfolioSkillService)
        {
            _portfolioSkillService = portfolioSkillService;
        }


        [HttpGet]
        [Route("GetAllPortfolioSkill")]
        public async Task<IActionResult> GetAllPortfolioSkill()
        {
            var values = await _portfolioSkillService.GetAllPortfolioSkillAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioSkill")]
        public IActionResult CreatePortfolioSkill()
        {
            return View();  
        }

        [HttpPost]
        [Route("CreatePortfolioSkill")]
        public async Task<IActionResult> CreatePortfolioSkill(CreatePortfolioSkillDto createPortfolioSkillDto)
        {
            await _portfolioSkillService.CreatePortfolioSkillAsync(createPortfolioSkillDto);
            return RedirectToAction("GetAllPortfolioSkill", "PortfolioSkill",new {area ="Admin"});
        }

        [HttpGet]
        [Route("UpdatePortfolioSkill/{id}")]
        public async Task<IActionResult> UpdatePortfolioSkill(int id)
        {
            var values = await _portfolioSkillService.GetPortfolioSkillByPortfolioSkillIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdatePortfolioSkill/{id}")]
        public async Task<IActionResult> UpdatePortfolioSkill(UpdatePortfolioSkillDto updatePortfolioSkillDto)
        {
            await _portfolioSkillService.UpdatePortfolioSkillAsync(updatePortfolioSkillDto);
            return RedirectToAction("GetAllPortfolioSkill", "PortfolioSkill",new {area="Admin"});
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioSkill/{id}")]
        public async Task<IActionResult> DeletePortfolioSkill(int id)
        {
            await _portfolioSkillService.DeletePortfolioSkillAsync(id);
            return RedirectToAction("GetAllPortfolioSkill", "PortfolioSkill",new {area="Admin"} );
        }
    }
}
