using homegains.Models;

namespace homegains.Services.DietPlanService
{
    public interface IDeitPlanService
    {

        Task<List<DietPlan>> GetAlldiet();
        Task<DietPlan> GetDaydietid(int id);
        Task Creatediet(DietPlan diet);
        Task Updatediet(int id, DietPlan diet);
        Task Deletediet(int id);
    }
}
