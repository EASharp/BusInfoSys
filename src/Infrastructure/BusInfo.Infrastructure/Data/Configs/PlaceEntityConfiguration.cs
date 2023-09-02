using System.Numerics;
using BusInfo.Core.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusInfo.Infrastructure.Data.Configs;

public class PlaceEntityConfiguration:IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.Property(p => p.Id).HasMaxLength(32);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.RouteNum);
        
    }
}