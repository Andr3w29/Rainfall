using Microsoft.OpenApi.Models;
using Rainfall.Api.Core.Application.Common.Interfaces.External;
using Rainfall.Api.Infrastructure.Services.External;
using System.Reflection;

#region Application Settings
var builder = WebApplication.CreateBuilder(args);
#endregion
// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region "Swagger Configuration"
builder.Services.AddSwaggerGen(options =>
{

    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "Rainfall Api",
        Description = "An API which provides rainfall reading data",
        Contact = new OpenApiContact
        {
            Name = "Sorted",
            Url = new Uri("https://www.sorted.com")
        },

    });
    options.AddServer(new OpenApiServer()
    {
        Description = "Rainfall Api",
        Url = "https://localhost:7032"
    });

    foreach (string filePath in Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)), "*.xml"))
    {
        options.IncludeXmlComments(filePath);
    }
});
#endregion
#region "Rainfall Configuration"
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpClient();
builder.Services.AddTransient<IRainfallService, RainfallService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
#endregion
var app = builder.Build();

#region "Swagger Configuration"
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.yaml", "Rainfall API");


});
#endregion

#region Standard Configurations
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion