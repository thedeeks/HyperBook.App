using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.ResponseModels
{
    public class CityWithInfoResponse
    {
        public string City { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public string Timezone { get; set; }
    }
}
