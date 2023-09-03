using BusInfo.Core.Interfaces;

namespace BusInfo.Core.Classes;

public class Route:ITypeBase

{
    public string Id { get; set; }
    public int Number { get; set; }
    public List<Place> Places { get; set; } = new();
}