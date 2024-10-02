
using homegains.Models;

namespace homegains.Controllers.UserController
{
    public class UserController : AllConnections
    {
        public int workId = 0;
        public bool daysShows = false; 

        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task changeWorkId(int id)
        {
            workId = id;
            daysShows = true;
            Shedules = await ShedulesServices.GetAllSheduless();
        }

        //Dayshow close
        public void dayShowFale()
        {
            daysShows = false;
        }

        //PAass and show another Page
        public async Task passData(int day, int ids)
        {
            Works = new();
            var workslis = await WorkServices.GetAllWorks();
            foreach (var worka in workslis)
            {
                if (worka.exerciseID == day && worka.WorkOutId == workId)// hri e unata description eka enne ne anika 
                {
                    Works.Add(worka);
                }
                else
                {
                    continue;
                }
            }
            NavigationManagers.NavigateTo("/User/BUTTW");
        }
    }
}
