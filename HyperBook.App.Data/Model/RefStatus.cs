using System;
using System.Collections.Generic;

#nullable disable

namespace HyperBook.App.Data.Model
{
    public partial class RefStatus
    {
        public RefStatus()
        {
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
