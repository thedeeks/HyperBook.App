using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperBook.App.Models.ResponseModels
{
    public class PodScheduleResponse
    {
        public int Id { get; set; }
        public int CityFrom { get; set; }
        public int CityTo { get; set; }
        public DateTime DepartureTimeGmt { get; set; }
        public DateTime ArrivalTimeGmt { get; set; }
        public decimal Price { get; set; }
    }
}
