using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces;

namespace BusInfo.Web.Models;

public class DriverViewModel : Driver, ITypeBase
{
    public bool isEdited { get; set; }
    public Bus? Bus { get; set; }
}