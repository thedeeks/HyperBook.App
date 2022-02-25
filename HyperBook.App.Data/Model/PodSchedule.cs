using System;
using System.Collections.Generic;

#nullable disable

namespace HyperBook.App.Data.Model
{
    public partial class PodSchedule
    {
        public PodSchedule()
        {
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public int CityFrom { get; set; }
        public int CityTo { get; set; }
        public string DepartureWindow { get; set; }
        public decimal Price { get; set; }

        public virtual City CityFromNavigation { get; set; }
        public virtual City CityToNavigation { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
