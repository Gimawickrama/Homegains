using homegains.Models;

namespace homegains.Services.BmiCalculatorService
{
    public interface IBmiCalculatorService
    {

        Task<List<BMI>> GetAllbmi();
        Task<BMI> GetDaybmiId(int id);
        Task Createbmi(BMI bmi);
        Task Updatebmi(int id, BMI bmi);
        Task Deletebmi(int id);
    }
}
