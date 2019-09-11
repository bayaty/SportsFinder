using System;
using System.Collections.Generic;
using System.Text;

namespace SportsFinder.Data.Models
{
    public class Event
    {
        public int EventId { get; set; }


        //NEED TO FIX THIS: TODO
        public int? CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime EventDate { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }
        public int SportId { get; set; }
        public virtual Sport Sport { get; set; }

        public int SkillLevelId { get; set; }
        public virtual SkillLevel SkillLevel { get; set; }
        
        //public User[] PlayersRejected { get; set; }
        public int PlayersNeeded { get; set; }

        public int GenderId { get; set; }
        public virtual PreferredGender Gender { get; set; }

        public string ShareLink { get; set; }

        public int EventStatusId { get; set; }
        public virtual EventStatus EventStatus { get; set; }

        public virtual List<Player> Players { get; set; }
        //maybe set user status ? currently stored in user
    }
}
