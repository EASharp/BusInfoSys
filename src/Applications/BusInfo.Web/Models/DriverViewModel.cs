using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces;

namespace BusInfo.Web.Models;

public class DriverViewModel : Driver, ITypeBase
{

    public Bus? Bus { get; set; }
    public bool IsCreate { get; set; } = false;

}