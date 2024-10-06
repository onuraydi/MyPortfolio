using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices;

namespace Portfolio.WebUI.ViewComponents.ProjectViewComponents
{
    public class _ProjectViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioProjectService _portfolioProjectService;

        public _ProjectViewComponentPartial(IPortfolioProjectService portfolioProjectService)
        {
            _portfolioProjectService = portfolioProjectService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioProjectService.GetAllPortfolioProjectAsync(); 
            return View(values);
        }
    }
}
