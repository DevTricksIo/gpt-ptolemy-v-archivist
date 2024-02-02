using Microsoft.Extensions.Configuration;

namespace ConsoleArchivistTester
{
    public  class SetUp
    {
        public IConfiguration Configuration { get; set; }

        public SetUp()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
