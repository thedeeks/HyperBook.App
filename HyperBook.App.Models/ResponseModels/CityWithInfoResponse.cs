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
        public string City { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string State { get; set; }
    }
}
