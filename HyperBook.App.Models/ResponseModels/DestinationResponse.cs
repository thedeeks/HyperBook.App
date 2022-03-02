using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.ResponseModels
{
    public class DestinationResponse
    {
        public int PodId { get; set; }
        public int CityFrom { get; set; }
        public string CityFromName { get; set; }
        public CityWithInfoResponse CityTo { get; set; }
        public string DepartureWindow { get; set; }
        public decimal Price { get; set; }
    }
}
