using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSkillServices;

namespace Portfolio.WebUI.ViewComponents.SkillViewComponents
{
    public class _SkillViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioSkillService _portfolioSkillService;

        public _SkillViewComponentPartial(IPortfolioSkillService portfolioSkillService)
        {
            _portfolioSkillService = portfolioSkillService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioSkillService.GetAllPortfolioSkillAsync();
            return View(values);
        }
    }
}
