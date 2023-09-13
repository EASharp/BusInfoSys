using BusInfo.Core.Interfaces;

namespace BusInfo.Core.Classes;

public class Place : ITypeBase
{
    public string Id { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string PlaceName { get; set; }
}