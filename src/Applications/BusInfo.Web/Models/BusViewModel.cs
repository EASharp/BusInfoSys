using BusInfo.Core.Classes;

namespace BusInfo.Web.Models;

public class BusViewModel : Bus
{
    public Driver Driver { get; set; }
    public bool IsCreate { get; set; }
}