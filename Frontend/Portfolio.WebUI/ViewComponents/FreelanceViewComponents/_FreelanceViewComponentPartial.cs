using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioFreelanceServices;

namespace Portfolio.WebUI.ViewComponents.FreelanceViewComponents
{
    public class _FreelanceViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioFreelanceService _portfolioFreelanceService;

        public _FreelanceViewComponentPartial(IPortfolioFreelanceService portfolioFreelanceService)
        {
            _portfolioFreelanceService = portfolioFreelanceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioFreelanceService.GetAllPortfolioFreelanceAsync();
            return View(values);
        }
    }
}
