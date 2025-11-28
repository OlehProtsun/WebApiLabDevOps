using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiLabDevOps.Dal.EntityFramework
{
    public class WetherForecastContext : DbContext
    {
        public WetherForecastContext(DbContextOptions<WetherForecastContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecastModel> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherForecatsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
