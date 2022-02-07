using System;
using System.Collections.Generic;

#nullable disable

namespace HyperBook.App.Data.Model
{
    public partial class User
    {
        public User()
        {
            Trips = new HashSet<Trip>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public virtual State StateNavigation { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
