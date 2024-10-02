using homegains.Data;
using homegains.Models;
using Microsoft.EntityFrameworkCore;

namespace homegains.services.ShedulesService
{
    public class ShedulesService : IShedulesService
    {
        public readonly ApplicationDbContext _context;

        public ShedulesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateShedules(Shedule Shedules)
        {
            _context.Sheduless.Add(Shedules);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShedules(int id)
        {
            var game = await _context.Sheduless.FindAsync(id);
            if (game != null)
            {
                _context.Sheduless.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Shedule>> GetAllSheduless()
        {
            var result = await _context.Sheduless.ToListAsync();
            return result; //ganna call ekek 
        }  

        public async Task<Shedule> GetShedulesById(int id)
        {
            var game = await _context.Sheduless.FindAsync(id);
            return game;
        }

        public async Task UpdateShedules(int id, Shedule Shedules)
        {
            var dbGame = await _context.Sheduless.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.planPrice = Shedules.planPrice;
                dbGame.days = Shedules.days;
               


                await _context.SaveChangesAsync();
            }
        }
    }
}
