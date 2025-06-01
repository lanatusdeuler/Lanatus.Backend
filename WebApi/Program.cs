using ApplicationInterfaces.ExternalServices;
using Infrastructures.Configures;
using Infrastructures.ExternalServices;
using Infrastructures.ExternalServices.Dtos;

namespace WebApi;

/// <summary>
///
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        builder.Services.AddOptions<AISettings>()
            .Bind(builder.Configuration.GetSection(AISettings.SectionName))
            .ValidateOnStart();

        builder.Services.AddOptions<GoogleSearchSettings>()
            .Bind(builder.Configuration.GetSection(GoogleSearchSettings.SectionName))
            .ValidateOnStart();

        builder.Services.AddOptions<BingSearchSettings>()
            .Bind(builder.Configuration.GetSection(BingSearchSettings.SectionName))
            .ValidateOnStart();

        builder.Services.AddTransient<GoogleSearchQueryBuilder>();

        builder.Services.AddHttpClient<BingSearchService>();
        builder.Services.AddHttpClient<GoogleSearchService>();
        builder.Services.AddTransient<WebSearchServiceFactory>();

        builder.Logging.AddConsole();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        app.Run();
    }
}