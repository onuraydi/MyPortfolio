using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioEducationServices;

namespace Portfolio.WebUI.ViewComponents.EducationComponents
{
    public class _EducationViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioEducationService _portfolioEducationService;

        public _EducationViewComponentPartial(IPortfolioEducationService portfolioEducationService)
        {
            _portfolioEducationService = portfolioEducationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioEducationService.GetAllPortfolioEducationAsync();
            return View(values);
        }
    }
}
