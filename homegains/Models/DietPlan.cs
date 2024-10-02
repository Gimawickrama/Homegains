using System.ComponentModel.DataAnnotations;

namespace homegains.Models
{
    public class DietPlan
    {
        [Key]
        public int Id { get; set; }
        public int DayId { get; set; }
        public string FoodItems { get; set; }
        public string FoodCatogary { get; set; } = "Standard Diet";
        public string DayCatogary { get; set; } = "Breakfast";
        public TimeOnly MealTime { get; set; }

    }
}
