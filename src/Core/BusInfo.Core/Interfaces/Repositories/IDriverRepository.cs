using BusInfo.Core.Classes;

namespace BusInfo.Core.Interfaces.Repositories;

public interface IDriverRepository : IRepositoryBase<Driver>
{
    public Task<Driver?> GetByLogPasswordAsync(string login, string password);
}