using homegains.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace homegains.services
{
    public interface IDayPlanService
    {
        Task<List<DayPlan>> GetAllDayPlans();
        Task<DayPlan> GetDayPlanById(int id);
        Task CreateDayPlan(DayPlan dayPlan);
        Task UpdateDayPlan(int id, DayPlan dayPlan);
        Task DeleteDayPlan(int id);
    }
}
