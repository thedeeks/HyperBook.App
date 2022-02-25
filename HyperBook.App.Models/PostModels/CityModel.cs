using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.PostModels
{
    public class CityModel
    {
        [Required]
        public string Name { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Timezone { get; set; }
    }
}
