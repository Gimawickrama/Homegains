using homegains.Models;

namespace homegains.services.ShedulesService
{
    public interface IShedulesService
    {

        Task<List<Shedule>> GetAllSheduless();
        Task<Shedule> GetShedulesById(int id);
        Task CreateShedules(Shedule Shedules);
        Task UpdateShedules(int id, Shedule Shedules);
        Task DeleteShedules(int id);

    }
}
