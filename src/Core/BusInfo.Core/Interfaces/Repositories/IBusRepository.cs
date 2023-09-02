using BusInfo.Core.Classes;

namespace BusInfo.Core.Interfaces.Repositories;

public interface IBusRepository:IRepositoryBase<Bus>

{
    public Task<Bus> GetByDriverIdAsync(string driverId);

}