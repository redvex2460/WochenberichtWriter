using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WochenberichtWriter.Application.Database;

namespace WochenberichtWriter.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(logg => 
                logg.AddConsole())
                .AddDbContext<DatabaseContext>()
                .BuildServiceProvider();
        }
    }
}