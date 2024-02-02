// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;

namespace ConsoleArchivist;

public class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();

        // Aqui você pode continuar com a lógica do seu aplicativo,
        // como instanciar o DbContext, etc.

        Console.WriteLine("Hello, World!");
    }

}