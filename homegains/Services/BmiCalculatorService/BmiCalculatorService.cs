using homegains.Controllers.AdminController;
using homegains.Data;
using homegains.Models;
using Microsoft.EntityFrameworkCore;

namespace homegains.Services.BmiCalculatorService
{
    public class BmiCalculatorService : IBmiCalculatorService
    {

        public readonly ApplicationDbContext _context;

        public BmiCalculatorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Createbmi(BMI bmi)
        {

            _context.BMIs.Add(bmi);
            await _context.SaveChangesAsync();
        }

        public async Task Deletebmi(int id)
        {
            var game = await _context.BMIs.FindAsync(id);
            if (game != null)
            {
                _context.BMIs.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BMI>> GetAllbmi()
        {
            var result = await _context.BMIs.ToListAsync();
            return result;
        }

        public async Task<BMI> GetDaybmiId(int id)
        {
            var game = await _context.BMIs.FindAsync(id);
            return game;
        }

        public async Task Updatebmi(int id, BMI bmi)
        {
            var dbGame = await _context.BMIs.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.ID = bmi.ID;
                dbGame.height = bmi.height;
                dbGame.weight = bmi.weight;

                await _context.SaveChangesAsync();
            }
        }
    }
}
