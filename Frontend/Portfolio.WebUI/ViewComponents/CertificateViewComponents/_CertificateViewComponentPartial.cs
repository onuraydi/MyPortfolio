using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioCertificateServices;

namespace Portfolio.WebUI.ViewComponents.CertificateViewComponents
{
    public class _CertificateViewComponentPartial:ViewComponent
    {
        private readonly IPortfolioCertificateService _portfolioCertificateService;

        public _CertificateViewComponentPartial(IPortfolioCertificateService portfolioCertificateService)
        {
            _portfolioCertificateService = portfolioCertificateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioCertificateService.GetAllPortfolioCertificateAsync();
            return View(values);
        }
    }
}
