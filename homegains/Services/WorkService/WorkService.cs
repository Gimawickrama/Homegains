using homegains.Data;
using homegains.Models;
using Microsoft.EntityFrameworkCore;

namespace homegains.services.WorkService
{
    public class WorkService : IWorkService
    {
        public readonly ApplicationDbContext _context;

        public WorkService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateWork(Work Work)
        {
            _context.Works.Add(Work);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWork(int id)
        {
            var game = await _context.Works.FindAsync(id);
            if (game != null)
            {
                _context.Works.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Work>> GetAllWorks()
        {
            var result = await _context.Works.ToListAsync();
            return result; //ganna call ekek 
        }

        public async Task<Work> GetWorkById(int id)
        {
            var game = await _context.Works.FindAsync(id);
            return game;
        }

        public async Task UpdateWork(int id, Work Work)
        {
            var dbGame = await _context.Works.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.title = Work.title;
                dbGame.description = Work.description;
                dbGame.repeat = Work.repeat;
                dbGame.animation = Work.animation;
                dbGame.unique = Work.unique;
                dbGame.exercise = Work.exercise;

                await _context.SaveChangesAsync();
            }
        }
    }
}
