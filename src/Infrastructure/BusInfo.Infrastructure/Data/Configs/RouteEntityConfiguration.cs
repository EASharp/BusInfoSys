using BusInfo.Core.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusInfo.Infrastructure.Data.Configs;

public class RouteEntityConfiguration:IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder
            .HasMany(p => p.Places)
            .WithMany();
        builder.HasKey(p => p.Id);
    }
}