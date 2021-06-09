using System.ComponentModel.DataAnnotations;

namespace ANB_WebApp.Models
{
    public class ViewModel
    {
        [Required]
        [Display(Name = "Enter Circle Radius For Calculations")]
        public decimal Radius { get; set; }
      
        public decimal Diameter { get; set; }
        public decimal Circumference { get; set; }
        public decimal Area { get; set; }

        [Display(Name = "Process Execution Status: ")]
        public string Status { get; set; }

        [Display(Name = "Process Execution Progress: ")]
        public int Progress { get; set; }

        [Display(Name = "Process Execution Time in MS: ")]
        public string ExceutionTime { get; set; }
    }
}
