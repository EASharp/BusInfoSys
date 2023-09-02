using BusInfo.Core.Interfaces;

namespace BusInfo.Core.Classes;

public class Driver:ITypeBase
{
    public string DriverName { get; set; }
    public string DriverSurname { get; set; }
    public string DriverLogin { get; set; }
    public string DriverPassword { get; set; }
    public string Id { get; set; }
}