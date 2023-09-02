using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusInfo.Infrastructure.Data.Configs;

public class BusEntityConfiguration:IEntityTypeConfiguration<Bus>
{
    public virtual void Configure(EntityTypeBuilder<Bus> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).HasMaxLength(32);
        builder.Property(p => p.DriverId).HasMaxLength(32);
        builder.HasIndex(p => p.BusNum);
        builder.HasIndex(p => p.RouteNum);
        

    }
}