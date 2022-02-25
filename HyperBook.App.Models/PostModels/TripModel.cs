using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.PostModels
{
    public class TripModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int PodSchedule { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}
