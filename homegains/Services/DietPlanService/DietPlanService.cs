using homegains.Controllers.AdminController;
using homegains.Data;
using homegains.Models;
using Microsoft.EntityFrameworkCore;

namespace homegains.Services.DietPlanService
{
    public class DietPlanService : IDeitPlanService
    {
        public readonly ApplicationDbContext _context;

        public DietPlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Creatediet(DietPlan diet)
        {

            _context.DietPlans.Add(diet);
            await _context.SaveChangesAsync();
        }

        public async Task Deletediet(int id)
        {
            var game = await _context.DietPlans.FindAsync(id);
            if (game != null)
            {
                _context.DietPlans.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DietPlan>> GetAlldiet()
        {
            var result = await _context.DietPlans.ToListAsync();
            return result;
        }

        public async Task<DietPlan> GetDaydietid(int id)
        {
            var game = await _context.DietPlans.FindAsync(id);
            return game;
        }

        public async Task Updatediet(int id, DietPlan diet)
        {
            var dbGame = await _context.DietPlans.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.Id = diet.Id;
                dbGame.FoodItems = diet.FoodItems;
                dbGame.FoodCatogary = diet.FoodCatogary;
                dbGame.DayCatogary = diet.DayCatogary;
                dbGame.MealTime=diet.MealTime;

                await _context.SaveChangesAsync();
            }
        }
    }
}
