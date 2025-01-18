using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices;

namespace Portfolio.WebUI.ViewComponents.FooterViewComponents
{
    public class _AskMeQuestionViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioAboutMeService _portfolioAboutMeService;

        public _AskMeQuestionViewComponentPartial(IPortfolioAboutMeService portfolioAboutMeService)
        {
            _portfolioAboutMeService = portfolioAboutMeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioAboutMeService.GetPortfolioAboutMeAsync();
            return View(values);
        }
    }
}
