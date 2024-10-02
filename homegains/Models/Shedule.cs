using System.ComponentModel.DataAnnotations;

namespace homegains.Models
{
    public class Shedule
    {
        [Key]
        public int ID { get; set; }
        public double planPrice { get; set; }
        public int days { get; set; }
    }
}
