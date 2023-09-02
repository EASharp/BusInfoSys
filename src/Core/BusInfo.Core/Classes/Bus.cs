using BusInfo.Core.Interfaces;

namespace BusInfo.Core.Classes;

public sealed class Bus:ITypeBase
{
    public string DriverId { get; set; }
    public string Id { get; set; }
    public string BusNum { get; set; }
    public int RouteNum { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool Enabled { get; set; }
    
                            
   
    
}