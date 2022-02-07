using System;
using System.Collections.Generic;

#nullable disable

namespace HyperBook.App.Data.Model
{
    public partial class City
    {
        public City()
        {
            PodScheduleCityFromNavigations = new HashSet<PodSchedule>();
            PodScheduleCityToNavigations = new HashSet<PodSchedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public int StateId { get; set; }
        public string Timezone { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<PodSchedule> PodScheduleCityFromNavigations { get; set; }
        public virtual ICollection<PodSchedule> PodScheduleCityToNavigations { get; set; }
    }
}
