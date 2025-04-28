using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme",opt =>
//{
//    opt.Authority = builder.Configuration["IdentityServerUrl"];
//    opt.Audience = "ResourceOcelot";
//});

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5002); // 5000 portundan HTTP baðlantý kabul et
});

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();

//app.UseHttpsRedirection();


app.MapGet("/", () => "Hello World!");

app.Run();
