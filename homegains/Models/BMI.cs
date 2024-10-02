using System.ComponentModel.DataAnnotations;

namespace homegains.Models
{
    public class BMI
    {
        [Key]
        public int ID { get; set; }
        public double height { get; set; }
        public int weight { get; set; }
    }
}
