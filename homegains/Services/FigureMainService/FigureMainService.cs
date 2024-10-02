using homegains.Data;
using homegains.Models;
using Microsoft.EntityFrameworkCore;

namespace homegains.services.FigureMainService
{
    public class FigureMainService :IFigureMainService
    {
        public readonly ApplicationDbContext _context;

        public FigureMainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateFigureMain(FigureMain FigureMain)
        {
            _context.FigureMains.Add(FigureMain);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFigureMain(int id)
        {
            var game = await _context.FigureMains.FindAsync(id);
            if (game != null)
            {
                _context.FigureMains.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<FigureMain>> GetAllFigureMains() 
        {
            var result = await _context.FigureMains.ToListAsync();
            return result;
        }

        public async Task<FigureMain> GetFigureMainById(int id)
        {
            var game = await _context.FigureMains.FindAsync(id);
            return game;
        }

        public async Task UpdateFigureMain(int id, FigureMain FigureMain)
        {
            var dbGame = await _context.FigureMains.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.SheduleDay = FigureMain.SheduleDay;
                dbGame.Title = FigureMain.Title;
                dbGame.Description = FigureMain.Description;
                dbGame.Time = FigureMain.Time;
                

                await _context.SaveChangesAsync();
            }
        }
    }
}
