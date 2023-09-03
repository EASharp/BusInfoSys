using AutoMapper;
using BusInfo.Core.Classes;
using BusInfo.Web.Models;

namespace BusInfo.Web.Mapping;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Driver, DriverViewModel>().ReverseMap();
        CreateMap<Bus, BusViewModel>().ReverseMap();
        
    }
}