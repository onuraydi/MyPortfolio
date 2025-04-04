﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;

namespace Portfolio.WebUI.ViewComponents.BlogUILayoutComponents.ContentComponents
{
    public class _BlogOtherBlogContentBlogUILayoutComponentPartial:ViewComponent
    {
        private readonly IPortfolioBlogService _portfolioBlogService;

        public _BlogOtherBlogContentBlogUILayoutComponentPartial(IPortfolioBlogService portfolioBlogService)
        {
            _portfolioBlogService = portfolioBlogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _portfolioBlogService.GetSuggestedPortfolioBlog();
            return View(values);
        }
    }
}
