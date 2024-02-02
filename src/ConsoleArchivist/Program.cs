using ConsoleArchivist.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ConsoleArchivist.Database;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using ConsoleArchivist.Services.Abstractions;

namespace ConsoleArchivist;

public class Program
{
    static async Task Main(string[] args)
    {

        //Configure a Generic Host
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(app =>
            {
                app.AddUserSecrets("55dcc747-60cd-49e2-9cc0-666934af5dee");
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ArchivistDbContext>(options =>
                {
                    var folder = Environment.SpecialFolder.LocalApplicationData;
                    var path = Environment.GetFolderPath(folder);
                    var dbPath = Path.Join(path, "translations.db");
                    options.UseSqlite($"Data Source={dbPath}");
                });

                services.AddHttpClient();

                services.AddHttpClient("GitHubHTTPClient", client =>
                {
                    var token = context.Configuration.GetSection("GitHubConfiguration:Token").Value;

                    client.BaseAddress = new Uri(context.Configuration.GetSection("GitHubConfiguration:BaseAddress").Value); ;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", token);
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));
                });

                services.AddHttpClient("OpenAIAPI", client =>
                {
                    var apiKey = context.Configuration.GetSection("OpenAIConfiguration:APIKey").Value;
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                    client.BaseAddress = new Uri(context.Configuration.GetSection("OpenAIConfiguration:BaseAddress").Value);
                });

                services.AddScoped<IGitHubService, GitHubService>();
                services.AddScoped<IOpenAIService, OpenAIService>();
                services.AddScoped<IPharaohBodyBuilderService, PharaohBodyBuilderService>();

                services.AddScoped<Startup>();

            })
            .Build();

        var startUp = host.Services.GetRequiredService<Startup>();

        await startUp.Run();
    }
}