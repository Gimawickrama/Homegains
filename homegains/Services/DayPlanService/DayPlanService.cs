using homegains.Data;
using homegains.Models;
using Microsoft.EntityFrameworkCore;

namespace homegains.services.DayPlanService
{
    public class DayPlanService : IDayPlanService
    {
        public readonly ApplicationDbContext _context;

        public DayPlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateDayPlan(DayPlan dayPlan)
        {
            _context.dayplans.Add(dayPlan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDayPlan(int id)
        {
            var game = await _context.dayplans.FindAsync(id);
            if (game != null)
            {
                _context.dayplans.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DayPlan>> GetAllDayPlans()
        {
            var result = await _context.dayplans.ToListAsync();
            return result;
        }

        public async Task<DayPlan> GetDayPlanById(int id)
        {
            var game = await _context.dayplans.FindAsync(id);
            return game;
        }

        public async Task UpdateDayPlan(int id, DayPlan dayPlan)
        {
            var dbGame = await _context.dayplans.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.UserId = dayPlan.UserId;
                dbGame.PaySuccess = dayPlan.PaySuccess;
                dbGame.SheduleId = dayPlan.SheduleId;

                await _context.SaveChangesAsync();
            }
        }
    }
}
