using System;
using System.Collections.Generic;

#nullable disable

namespace HyperBook.App.Data.Model
{
    public partial class Trip
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int PodSchedule { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual PodSchedule PodScheduleNavigation { get; set; }
        public virtual RefStatus Status { get; set; }
        public virtual User User { get; set; }
    }
}
