using System;
using System.Collections.Generic;

#nullable disable

namespace HyperBook.App.Data.Model
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
