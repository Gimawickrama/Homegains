using System.ComponentModel.DataAnnotations;

namespace homegains.Models
{
    public class FigureMain
    {
        [Key]
        public int Id { get; set; }
        public string SheduleDay { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
    }
}
