using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using ScreenSound.Banco;


namespace ScreenSound.Shared.Dados
{
    public class ScreenSoundContextFactory : IDesignTimeDbContextFactory<ScreenSoundContext>
    {
        public ScreenSoundContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ScreenSoundContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new ScreenSoundContext(optionsBuilder.Options);
        }
    }
}
