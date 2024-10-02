using System.ComponentModel.DataAnnotations;

namespace homegains.Models
{
    public class DayPlan
    {
        [Key]
        public int Id { get; set; }
        public int SheduleId { get; set; }
        public bool PaySuccess { get; set; }
        public int UserId { get; set; }
    }
}
