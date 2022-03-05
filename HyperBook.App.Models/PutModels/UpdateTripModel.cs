using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.PutModels
{
    public class UpdateTripModel
    {
        [Required]
        public int TripId { get; set; }
        [Required]
        public int RefStatusId { get; set; }
    }
}
