using homegains.Models;

namespace homegains.services.FigureMainService
{
    public interface IFigureMainService
    {
        Task<List<FigureMain>> GetAllFigureMains();
        Task<FigureMain> GetFigureMainById(int id);
        Task CreateFigureMain(FigureMain FigureMain);
        Task UpdateFigureMain(int id, FigureMain FigureMain);
        Task DeleteFigureMain(int id);
    }
}
