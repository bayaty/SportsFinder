using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsFinder.Data.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string DisplayName { get; set; }

       
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<UserSport> FavouriteSports { get; set; }

        //private attributes, only user can see
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        //Used during creation,deletion,joining of events
    }
}
