using homegains.Controllers.CustomModels;
using homegains.Models;
using homegains.services.FigureMainService;
using homegains.services.ShedulesService;
using homegains.services.WorkService;
using homegains.Services.DietPlanService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace homegains.Controllers
{
    public class AllConnections : NewConnections
    {
        public IShedulesService ShedulesServices { get; private set; }
        public IFigureMainService FigureMainServices { get; private set; }
        public IWebHostEnvironment WebHostEnvironments { get; private set; }
        public IDeitPlanService DeitPlanServices { get; private set; }
        public IWorkService WorkServices { get; private set; }

		public NavigationManager NavigationManagers { get; private set; }

        public AllConnections(IServiceProvider serviceProvider)
        {
            NavigationManagers = serviceProvider.GetRequiredService<NavigationManager>();
            ShedulesServices = serviceProvider.GetRequiredService<IShedulesService>();
			FigureMainServices = serviceProvider.GetRequiredService<IFigureMainService>();
			WebHostEnvironments = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            DeitPlanServices = serviceProvider.GetRequiredService<IDeitPlanService>();
            WorkServices = serviceProvider.GetRequiredService<IWorkService>();
		}

        public List<Shedule> Shedules = new List<Shedule>();
        public List<DietPlan> DietPlanls = new List<DietPlan>();
        public List<Work> Works = new List<Work>();
        public List<WorkoutModel> WorkoutModels = new List<WorkoutModel>();
    }
}
