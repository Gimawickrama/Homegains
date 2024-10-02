using System.ComponentModel.DataAnnotations;

namespace homegains.Models
{
    public class Work
    {
        [Key]
        public int Id { get; set; }
        public int WorkOutId { get; set; }
        public int exerciseID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int repeat { get; set; }
        public string animation { get; set; }
        public int unique { get; set; }
        public bool exercise { get; set; }
    }
}
 