using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioExperienceServices;

namespace Portfolio.WebUI.ViewComponents.ExperienceViewComponents
{
    public class _ExperienceViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioExperienceService _portfolioExperienceService;

        public _ExperienceViewComponentPartial(IPortfolioExperienceService portfolioExperienceService)
        {
            _portfolioExperienceService = portfolioExperienceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioExperienceService.GetAllPortfolioExperienceAsync();
            return View(values);
        }
    }
}
