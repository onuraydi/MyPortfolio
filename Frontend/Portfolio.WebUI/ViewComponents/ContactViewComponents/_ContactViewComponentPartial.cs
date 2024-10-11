using Microsoft.AspNetCore.Mvc;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioContactDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices;

namespace Portfolio.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioContactService _portfolioContactService;

        public _ContactViewComponentPartial(IPortfolioContactService portfolioContactService)
        {
            _portfolioContactService = portfolioContactService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CreatePortfolioContactDto createPortfolioContactDto)
        {
            await _portfolioContactService.CreatePortfolioContactAsync(createPortfolioContactDto);
            return View();
        }
    }
}
