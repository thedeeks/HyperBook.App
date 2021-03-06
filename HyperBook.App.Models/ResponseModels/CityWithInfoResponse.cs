using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.ResponseModels
{
    public class CityWithInfoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public string State { get; set; }
        public string Timezone { get; set; }
    }
}
