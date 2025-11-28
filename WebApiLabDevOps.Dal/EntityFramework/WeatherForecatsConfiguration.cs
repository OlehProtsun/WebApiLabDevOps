using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiLabDevOps.Dal.EntityFramework
{
    public class WeatherForecatsConfiguration : IEntityTypeConfiguration<WeatherForecastModel>
    {
        public void Configure(EntityTypeBuilder<WeatherForecastModel> builder)
        {
            builder.ToTable("WeatherForecasts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Date)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(x => x.TemperatureC)
                   .IsRequired();

            builder.Property(x => x.TemperatureF)
                   .IsRequired();

            builder.Property(x => x.Summary)
                   .HasMaxLength(256);
        }
    }
}
