using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioCertificateServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioEducationServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioExperienceServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSkillServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioTechnologyServices;
using Portfolio.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IImageUploadService, ImageUploadService>();

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();


builder.Services.AddHttpClient<IPortfolioMainTitleService, PortfolioMainTitleService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioAboutMeService, PortfolioAboutMeService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioExperienceService, PortfolioExperienceService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioTechnologyService, PortfolioTechnologyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioSkillService, PortfolioSkillService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioProjectService, PortfolioProjectService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioBlogService, PortfolioBlogService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioCertificateService, PortfolioCertificateService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioEducationService, PortfolioEducationService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioContactService, PortfolioContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});


builder.Services.AddHttpClient<IPortfolioBlogCommentService, PortfolioBlogCommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});



builder.Services.AddHttpClient<IPortfolioBlogTagServices, PortfolioBlogTagServices>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
