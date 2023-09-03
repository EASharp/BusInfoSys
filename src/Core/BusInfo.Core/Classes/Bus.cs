using BusInfo.Core.Interfaces;

namespace BusInfo.Core.Classes;

public class Bus:ITypeBase
{
    public string DriverId { get; set; }
    public string Id { get; set; }
    public string BusNum { get; set; }
    public int RouteNum { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    
    public bool Enabled { get; set; }
    
}