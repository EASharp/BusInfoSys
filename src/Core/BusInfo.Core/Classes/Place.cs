using BusInfo.Core.Interfaces;

namespace BusInfo.Core.Classes;

public class Place:ITypeBase
{
    public string Id { get; set; }
    public int RouteNum { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string PlaceName { get; set; }
    
}