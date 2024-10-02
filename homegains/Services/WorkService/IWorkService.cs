using homegains.Models;

namespace homegains.services.WorkService
{
    public interface IWorkService
    {
        Task<List<Work>> GetAllWorks();
        Task<Work> GetWorkById(int id);
        Task CreateWork(Work Work);
        Task UpdateWork(int id, Work Work);
        Task DeleteWork(int id);
    }
}
