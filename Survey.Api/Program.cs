using Microsoft.EntityFrameworkCore;
using Survey.Api;
using Survey.Api.Interfaces;
using Survey.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy => policy.AddPolicy("default", opt =>
{
    opt.AllowAnyHeader();
    opt.AllowCredentials();
    opt.AllowAnyMethod();
}));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<ISurveyService, SurveyService>();

builder.WebHost.UseUrls("http://*:5000", "https://*:5001");
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); 
    options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); 
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("default");

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});

app.UseAuthorization();
app.MapControllers();

app.Run();