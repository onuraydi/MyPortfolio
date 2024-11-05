using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Services.LibraryServices.BookServices;
using MyPortfolio.WebApi.Services.PortfolioAboutMeServices;
using MyPortfolio.WebApi.Services.PortfolioBlogCommentServices;
using MyPortfolio.WebApi.Services.PortfolioBlogServices;
using MyPortfolio.WebApi.Services.PortfolioCertificateServices;
using MyPortfolio.WebApi.Services.PortfolioContactServices;
using MyPortfolio.WebApi.Services.PortfolioEducationServices;
using MyPortfolio.WebApi.Services.PortfolioExperienceServices;
using MyPortfolio.WebApi.Services.PortfolioMainTitleServices;
using MyPortfolio.WebApi.Services.PortfolioProjectServices;
using MyPortfolio.WebApi.Services.PortfolioSkillServices;
using MyPortfolio.WebApi.Services.PortfolioTechnologyServices;
using MyPortfolio.WebApi.Services.ProjectImageServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PortfolioContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IPortfolioMainTitleService, PortfolioMainTitleService>();
builder.Services.AddScoped<IPortfolioAboutMeService, PortfolioAboutMeService>();
builder.Services.AddScoped<IPortfolioExperienceService, PortfolioExperienceService>();
builder.Services.AddScoped<IPortfolioSkillService, PortfolioSkillService>();
builder.Services.AddScoped<IPortfolioCertificateService, PortfolioCertificateService>();
builder.Services.AddScoped<IPortfolioEducationService, PortfolioEducationService>();
builder.Services.AddScoped<IPortfolioProjectService, PortfolioProjectService>();
builder.Services.AddScoped<IPortfolioTechnologyService, PortfolioTechnologyService>();
builder.Services.AddScoped<IPortfolioBlogService, PortfolioBlogService>();
builder.Services.AddScoped<IPortfolioContactService, PortfolioContactService>();
builder.Services.AddScoped<IPortfolioBlogCommentService, PortfolioBlogCommentService>();
builder.Services.AddScoped<IProjectImageService, ProjectImageService>();


builder.Services.AddScoped<IBookService, BookService>();



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
