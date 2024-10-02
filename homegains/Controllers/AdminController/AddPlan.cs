
using homegains.Controllers.CustomModels;
using homegains.Models;
using homegains.services.WorkService;
using homegains.Services.DietPlanService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace homegains.Controllers.AdminController
{
    public class AddPlan : AllConnections
    {
        public int dayid = 0;
        public bool showDwetailsAdd = false;
        public bool fullBody = false;
        public bool successFullMessage = false;
        public bool updateShow = false;
        public bool DayDel = false;
        public int day = 0;
        public bool updateDay = false;
        public bool shwDays = false;
        public bool hideShowDiet = false;


        //VideoUploading Part Variable
        private string UploadedImage1 { get; set; }
		private string path1 { get; set; }

        private string UploadedImage2 { get; set; }
        private string path2 { get; set; }

        private string UploadedImage3 { get; set; }
        private string path3 { get; set; }

        private string UploadedImage4 { get; set; }
        private string path4 { get; set; }

        public AddPlan(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        //Add Data For the shedules
        public async Task AddDayPlan()
        {
            await ShedulesServices.CreateShedules(SheduleList);
            await ShowAllAddDayPlan();
            NavigationManagers.NavigateTo("/DayPlanAdd", forceLoad:true);
        }

        //AllData Get From Shedule
        public async Task ShowAllAddDayPlan()
        {
            try
            {
                Shedules = await ShedulesServices.GetAllSheduless();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        //Forcus Load The Add Data Shedules Data
        public async Task GetIdAndAsyncData(int id, int dayRealId)
        {
            day = id;
            dayid = dayRealId;
            showDwetailsAdd = true;
            WorkoutModels = new List<WorkoutModel>();
        }

        //Close Button Generated
        public  void CloseBtnAddPlan()
        {
            if(showDwetailsAdd == true)
            {
                showDwetailsAdd = false;
                successFullMessage = false;
                WorkoutModels = new List<WorkoutModel>();
            }
        }

        //ShowFullBody WorkOut
        public async Task ViewFullBodyWorkOut()
        {
            showDwetailsAdd = false;
            successFullMessage = false;
            fullBody = true;
        }

        //Back to the ViewPage
        public void closebackViewPage()
        {
            fullBody = false;
            showDwetailsAdd = true;
            successFullMessage = false;
            WorkoutModels = new List<WorkoutModel>();
        }

		//Add Video Uploading
		public async Task HandleFileSelected1(InputFileChangeEventArgs e)
        {
			var file = e.File;
			if (file != null)
			{
				if (file.Size > 10 * 1024 * 1024) // Limiting file size to 10 MB
				{
					// Reset the file input to clear the selected file
					//await JSRuntime.InvokeVoidAsync("resetInput", "fileInput");
					Console.WriteLine("File size exceeds the limit (10 MB).");
					return;
				}

				var folderPath = Path.Combine(WebHostEnvironments.WebRootPath, "videos");
				Directory.CreateDirectory(folderPath);
				var filePath = Path.Combine(folderPath, file.Name);
                path1 = file.Name;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }
                
			}
		}

        public async Task HandleFileSelected2(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file != null)
            {
                if (file.Size > 10 * 1024 * 1024) // Limiting file size to 10 MB
                {
                    // Reset the file input to clear the selected file
                    //await JSRuntime.InvokeVoidAsync("resetInput", "fileInput");
                    Console.WriteLine("File size exceeds the limit (10 MB).");
                    return;
                }

                var folderPath = Path.Combine(WebHostEnvironments.WebRootPath, "videos");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, file.Name);
                path2 = file.Name;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }

            }
        }

        public async Task HandleFileSelected3(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file != null)
            {
                if (file.Size > 10 * 1024 * 1024) // Limiting file size to 10 MB
                {
                    // Reset the file input to clear the selected file
                    //await JSRuntime.InvokeVoidAsync("resetInput", "fileInput");
                    Console.WriteLine("File size exceeds the limit (10 MB).");
                    return;
                }

                var folderPath = Path.Combine(WebHostEnvironments.WebRootPath, "videos");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, file.Name);
                path3 = file.Name;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }

            }
        }

        public async Task HandleFileSelected4(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file != null)
            {
                if (file.Size > 10 * 1024 * 1024) // Limiting file size to 10 MB
                {
                    // Reset the file input to clear the selected file
                    //await JSRuntime.InvokeVoidAsync("resetInput", "fileInput");
                    Console.WriteLine("File size exceeds the limit (10 MB).");
                    return;
                }

                var folderPath = Path.Combine(WebHostEnvironments.WebRootPath, "videos");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, file.Name);
                path4 = file.Name;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(stream);
                }

            }
        }

        public async Task AddFullBodyWork(int mode)
		{
            try
            {
                WorkList1.exerciseID = WorkList2.exerciseID = WorkList3.exerciseID = WorkList4.exerciseID = dayid;
                if (mode == 0)
                {
                    UploadedImage1 = "videos/" + path1;
                    WorkList1.animation = UploadedImage1;
                    WorkList1.WorkOutId = mode;
                    await WorkServices.CreateWork(WorkList1);
                }
                else if (mode == 1)
                {
                    UploadedImage2 = "videos/" + path2;
                    WorkList2.animation = UploadedImage2;
                    WorkList2.WorkOutId = mode;
                    await WorkServices.CreateWork(WorkList2);
                }
                else if (mode == 2)
                {
                    UploadedImage3 = "videos/" + path3;
                    WorkList3.animation = UploadedImage3;
                    WorkList3.WorkOutId = mode;
                    await WorkServices.CreateWork(WorkList3);
                }
                else if (mode == 3)
                {
                    UploadedImage4 = "videos/" + path4;
                    WorkList4.animation = UploadedImage4;
                    WorkList4.WorkOutId = mode;
                    await WorkServices.CreateWork(WorkList4);
                }
            }
            catch (Exception ex)
            {
                return;
            }
            finally{
                showDwetailsAdd = false;
                fullBody = false;
                successFullMessage = true;

    }
		}

        //Successfull Message Remover
        public void SuccessFullMessage ()
        {
            successFullMessage = false;
            showDwetailsAdd = true;
            WorkList1 = new Work();
            WorkList2 = new Work();
            WorkList3 = new Work();
            WorkList4 = new Work();
        }


        private int worksid;

        //View The Data 
        public async Task AllDataShow(int workId)
        {
            worksid = workId;
            var AllRead = await WorkServices.GetAllWorks();
            var ShedulePrice = await ShedulesServices.GetShedulesById(dayid);
            foreach (var Work in AllRead)
            {

                if (Work.WorkOutId == workId && dayid == Work.exerciseID)
                {
                    /*Works.Add(new Work()
                    {
                        description = Work.description,
                    });*/
                    //Works.Add(Work);
                    WorkoutModels.Add(new WorkoutModel()
                    {
                        id= Work.Id,
                        title = Work.title,
                        description = Work.description, 
                        planPrice = ShedulePrice.planPrice
                    });
                }

            }
            showDwetailsAdd = false;
            fullBody = true;
        }

        //Delete workout
        public async Task deleteWorkOut(int id)
        {
            await WorkServices.DeleteWork(id);
            WorkoutModels = new List<WorkoutModel>();
            await AllDataShow(worksid);
        }

        private int updateid;

        //async updateid
        public async Task updateIdAsync(int id)
        {
            updateid = id;
            WorkList3 = await WorkServices.GetWorkById(id);
            updateShow = true;
            DayDel = false;
            showDwetailsAdd = false;
            fullBody = false;
        }

        //update workout
        public async Task updateWorkout()
        {
            UploadedImage3 = "videos/" + path3;
            WorkList3.animation = UploadedImage3;
            await WorkServices.UpdateWork(updateid, WorkList3);
            WorkoutModels = new List<WorkoutModel>();
            updateShow = false;

        }

        //Cancel Update
        public void CancelUpdate()
        {
            updateShow = false;
        }

        //Day Delete Switch
        public void deleteDaySw()
        {
            DayDel = true;
        }

        //Day Delete Cancel Switch
        public void DaydelCncel()
        {
            DayDel = false;
        }

        //Day Delete ON Process
        public async Task deleteDate()
        {
            
            DayDel = false;
            showDwetailsAdd = false;
            fullBody = false;
            await ShedulesServices.DeleteShedules(dayid);
            await ShowAllAddDayPlan();
        }

        //Day Update
        public async Task DayUpdate()
        {
            SheduleList1 = new();
            SheduleList1 = await ShedulesServices.GetShedulesById(dayid);
            updateDay = true;
        }


        //Day UpdateCancel
        public void DayUpdateCancel()
        {
            updateDay = false;
        }

        //Day Update Real
        public async Task DayUpdateReal()
        {
            await ShedulesServices.UpdateShedules(dayid, SheduleList1);
            updateDay = false;
        }


        //Navigate To Pricing
        public void NavigatePrice()
        {
            NavigationManagers.NavigateTo("/User/Pricing");

		}

        //load All days
        public async Task loadAllDays()
        {
            Shedules = new();
            Shedules = await ShedulesServices.GetAllSheduless();
        }

        private int did;
        //show dayPlan Ad
        public async Task showDayPlanAdd(int id)
        {
            did = id;
            shwDays = true;
            await loadDietPlans();
        }


        //Show DayPlan dis
        public void closeDayPlan()
        {
            shwDays = false;
        }

        public TimeOnly time = TimeOnly.MaxValue;

        //Add diat Plan
        public async Task AddDiatPlan()
        {
            try
            {

                DietPlans.DayId = did;
                await DeitPlanServices.Creatediet(DietPlans);
                DietPlanls = new();
                await loadDietPlans();
                
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                DietPlans = new();
            }

        }

        //Delete DayPlan
        public async Task deleteDietPlan(int id)
        {
            await DeitPlanServices.Deletediet(id);
            DietPlanls = new();
            await loadDietPlans();

        }

        //Load DiatPaln
        private async Task loadDietPlans()
        {
            try
            {
                var diatPlAll = await DeitPlanServices.GetAlldiet();
                foreach (var dit in diatPlAll)
                {
                    if (did == dit.DayId)
                    {
                        DietPlanls.Add(dit);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private int ditid = 0;
        //Update Diat Plan
        public async Task loadDataAndUpdate(int id)
        {
            ditid = id;
            DietPlans = new();
            DietPlans = await DeitPlanServices.GetDaydietid(id);
            hideShowDiet = true;
        }

        //Update Dieat Plan real
        public async Task UpdatedietPlan()
        {
            await DeitPlanServices.Updatediet(ditid, DietPlans);
            DietPlans = new();
            hideShowDiet = false;
        }
    }
}
