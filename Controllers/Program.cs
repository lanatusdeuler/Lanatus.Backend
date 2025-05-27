using Infrastructures.Configures;
using Infrastructures.ExternalServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace Applications;

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

        builder.Services.AddHttpClient<OpenAIChatCompletionService>((serviceProvider, httpClient) =>
        {
            AISettings settings = serviceProvider
                .GetRequiredService<IOptions<AISettings>>()
                .Value;

            httpClient.BaseAddress = settings.AICredentials.EndPoint;
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", settings.AICredentials.Credential);
        });

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