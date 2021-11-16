using Hahn.ApplicatonProcess.July2021.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace Hahn.ApplicationProcess.July2021.Web
{
    public class HahnContextFactory : IDesignTimeDbContextFactory<HahnDbContext>
    {
        public HahnDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .Build();

            var builder = new DbContextOptionsBuilder<HahnDbContext>();
            var connectionString = configuration.GetConnectionString("dbConnectionString");

            builder.UseSqlServer(connectionString);

            return new HahnDbContext(builder.Options);
        }
    }
}
