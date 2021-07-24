using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ado_hw_15
{
    public class Configures
    {
        private IConfigurationRoot config;
        public Configures(string jsonFile)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(jsonFile);
            config = builder.Build();
        }
        public DbContextOptions<OlympiadContext> GetOptions(string nameConnectionString)
        {
            string connectionString = config.GetConnectionString(nameConnectionString);
            var optionsBuilder = new DbContextOptionsBuilder<OlympiadContext>();
            optionsBuilder.EnableSensitiveDataLogging();
            return optionsBuilder.UseSqlServer(connectionString).Options;
        }
        public string GetStringParameter(string key) => config[key];
    }
}
