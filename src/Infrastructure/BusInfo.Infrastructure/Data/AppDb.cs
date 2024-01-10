using System.Reflection;
using BusInfo.Core.Classes;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data;

public class AppDb : DbContext
{
    public DbSet<Place> Places { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Driver> Drivers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=;Database=BusInfo;Uid=;Pwd=;",
            MariaDbServerVersion.LatestSupportedServerVersion);
    }
}
