using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperBook.App.Data.Model;


namespace HyperBook.App.Models.ResponseModels
{
    public class TripResponse
    {
        public Guid UserId { get; set; }
        public PodResponse PodSchedule { get; set; }
        public string RefStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public int TripId { get; set; }
    }

    public class PodResponse
    {
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public string DepartureWindow { get; set; }
        public decimal Price { get; set; }

    }
}
