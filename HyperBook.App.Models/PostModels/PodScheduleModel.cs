using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.PostModels
{
    public class PodScheduleModel
    {
        [Required]
        public int CityFrom { get; set; }
        [Required]
        public int CityTo { get; set; }
        [Required]
        public string DepartureWindow { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
