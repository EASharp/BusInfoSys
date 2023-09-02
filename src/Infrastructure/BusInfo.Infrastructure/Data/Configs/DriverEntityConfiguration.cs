using BusInfo.Core.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusInfo.Infrastructure.Data.Configs;

public class DriverEntityConfiguration:IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.Property(p => p.Id).HasMaxLength(32);
        builder.HasKey(p => p.Id);
    }
}