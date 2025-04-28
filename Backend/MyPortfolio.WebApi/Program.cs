using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyPortfolio.WebApi.Context;
using MyPortfolio.WebApi.Services.BlogCategoryServices;
using MyPortfolio.WebApi.Services.LibraryServices.BookServices;
using MyPortfolio.WebApi.Services.NotificationServices;
using MyPortfolio.WebApi.Services.PorfolioFreelanceServices;
using MyPortfolio.WebApi.Services.PortfolioAboutMeServices;
using MyPortfolio.WebApi.Services.PortfolioBlogCommentServices;
using MyPortfolio.WebApi.Services.PortfolioBlogServices;
using MyPortfolio.WebApi.Services.PortfolioBlogTagServices;
using MyPortfolio.WebApi.Services.PortfolioCertificateServices;
using MyPortfolio.WebApi.Services.PortfolioContactServices;
using MyPortfolio.WebApi.Services.PortfolioEducationServices;
using MyPortfolio.WebApi.Services.PortfolioExperienceServices;
using MyPortfolio.WebApi.Services.PortfolioMainTitleServices;
using MyPortfolio.WebApi.Services.PortfolioProjectFooterServices;
using MyPortfolio.WebApi.Services.PortfolioProjectServices;
using MyPortfolio.WebApi.Services.PortfolioRoutingFooterServices;
using MyPortfolio.WebApi.Services.PortfolioSkillServices;
using MyPortfolio.WebApi.Services.PortfolioSocialMediaFooterServices;
using MyPortfolio.WebApi.Services.PortfolioTechnologyServices;
using MyPortfolio.WebApi.Services.ProjectImageServices;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PortfolioContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});




builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // 5000 portundan HTTP baðlantý kabul et
});

#region

//builder.Services.AddIdentity<User, Role>()
//    .AddEntityFrameworkStores<PortfolioContext>()
//    .AddDefaultTokenProviders();


//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(options =>
//    {
//        options.RequireHttpsMetadata = false;
//        options.SaveToken = true;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
//            ValidAudience = builder.Configuration["JWT:ValidAudience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
//        };
//    });

#endregion



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourcePortfolioAdmin";
    opt.RequireHttpsMetadata = false;
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ResourcePortfolioAdmin", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == "aud" && (c.Value == "ResourcePortfolioAdmin" || c.Value == "ResourcePortfolio"))
        ));
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
builder.Services.AddScoped<IPortfolioBlogTagService, PortfolioBlogTagService>();
builder.Services.AddScoped<IPortfolioSocialMediaFooterService, PortfolioSocialMediaFooterService>();
builder.Services.AddScoped<IPortfolioFreelanceService, PortfolioFreelanceServices>();
builder.Services.AddScoped<IPortfolioRoutingFooterService, PortfolioRoutingFooterService>();
builder.Services.AddScoped<IPortfolioProjectFooterService, PortfolioProjectFooterService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IBlogCategoryService, BlogCategoryService>();

builder.Services.AddScoped<IBookService, BookService>();



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>

{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()

    {

        Name = "Authorization",

        Type = SecuritySchemeType.ApiKey,

        Scheme = "Bearer",

        BearerFormat = "JWT",

        In = ParameterLocation.Header,

        Description = "Bearer yazýp boþluk býrakýp tokeni girebilirsiniz",

    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()

    {

        {

            new OpenApiSecurityScheme

            {

                Reference = new OpenApiReference

                {

                    Type = ReferenceType.SecurityScheme,

                    Id = "Bearer"

                }

            },

            Array.Empty<string>()

        }

    });

});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // CORS politikasýný uygulayýn
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
