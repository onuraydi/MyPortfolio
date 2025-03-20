using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Portfolio.WebUI.Handlers;
using Portfolio.WebUI.Services.IdentityServices.Abstract;
using Portfolio.WebUI.Services.IdentityServices.Concrete;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;
using Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices;
using Portfolio.WebUI.Services.PortfolioServices.LoginServices;
using Portfolio.WebUI.Services.PortfolioServices.NotificationServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioAboutMeServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogCommentServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioCertificateServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioContactServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioEducationServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioExperienceServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioFreelanceServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioMainTitleServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectfooterServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioProjectServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioRoutingFooterServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSkillServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioSocialMediaFooterServices;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioTechnologyServices;
using Portfolio.WebUI.Settings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IImageUploadService, ImageUploadService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Login";
    opt.LogoutPath = "/deneme/index";
    opt.AccessDeniedPath = "/Login/Login";  // eriþimi olmayan sayfaya eriþmeye çalýþýrsa
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "PortfolioJWTCookie";
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Login";
    opt.LogoutPath = "/deneme/index/";
    opt.ExpireTimeSpan = TimeSpan.FromDays(1);
    opt.Cookie.Name = "PortfolioCookie";
    opt.SlidingExpiration = true;

});



builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();


builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));





builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioMainTitleService, PortfolioMainTitleService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioAboutMeService, PortfolioAboutMeService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioExperienceService, PortfolioExperienceService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioTechnologyService, PortfolioTechnologyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioSkillService, PortfolioSkillService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioProjectService, PortfolioProjectService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioBlogService, PortfolioBlogService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioCertificateService, PortfolioCertificateService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioEducationService, PortfolioEducationService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioContactService, PortfolioContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddHttpClient<IPortfolioBlogCommentService, PortfolioBlogCommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();



builder.Services.AddHttpClient<IPortfolioBlogTagServices, PortfolioBlogTagServices>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IPortfolioSocialMediaFooterService, PortfolioSocialMediaFooterService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IPortfolioFreelanceService, PortfolioFreelanceService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IPortfolioRoutingFooterService, PortfolioRoutingFooterService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IPortfolioProjectFooterService, PortfolioProjectFooterService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<INotificationService, NotificationService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IBlogCategoryService, BlogCategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


//builder.Services.AddHttpClient<IloginServices, LoginServices>(opt =>
//{
//    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Portfolio.Path}");
//});

//builder.Services.AddHttpClient<IIdentityService, IdentityServices>(opt =>
//{
//    opt.BaseAddress = new Uri($"{values.IdentityServerUrl}");
//}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


//builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>(opt =>
//{
//    opt.BaseAddress = new Uri($"{values.IdentityServerUrl}");
//}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


builder.Services.AddScoped<IloginServices, LoginServices>();




builder.Services.AddHttpClient<IIdentityService, IdentityServices>();



builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();



builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();



builder.Services.AddHttpClient();



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Portfolio}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
