using ConsoleArchivist.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

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
                services.AddHttpClient();                

                services.AddHttpClient("GitHubHTTPClient", client =>
                {
                    var owner = context.Configuration.GetSection("GitHubConfiguration:Owner").Value;
                    var repo = context.Configuration.GetSection("GitHubConfiguration:Repo").Value;

                    var token = context.Configuration.GetSection("GitHubConfiguration:Token").Value;

                    client.BaseAddress = new Uri($"https://api.github.com/repos/{owner}/{repo}/contents");
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GPTPtolemyVArchivist", "1.0"));
                });

                services.AddScoped<IGitHubService, GitHubService>();

                services.AddScoped<Startup>();


            })
            .Build();


        //host.Con

        //builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();
        //builder.Configuration.AddJsonFile("hostsettings.json", optional: true);
        //builder.Configuration.AddEnvironmentVariables(prefix: "PREFIX_");
        //builder.Configuration.AddCommandLine(args);


        var startUp = host.Services.GetRequiredService<Startup>();

        await startUp.Run();



        //var builder = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        //Configuration = builder.Build();




        //    builder.Services.AddHttpClient(
        //httpClientName,
        //client =>
        //{
        //    // Set the base address of the named client.
        //    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        //    // Add a user-agent default request header.
        //    client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
        //});

        //    // Aqui você pode continuar com a lógica do seu aplicativo,
        //    // como instanciar o DbContext, etc.

        //    //var ghClient = GitHubAPIClient.Instance;

        //    Console.WriteLine("Hello, World!");
    }
}