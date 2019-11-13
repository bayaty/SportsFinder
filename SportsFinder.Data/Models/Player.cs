using System.ComponentModel.DataAnnotations.Schema;

namespace SportsFinder.Data.Models
{
    public class Player //User+Event Junction Table.
    {
        public int PlayerId { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public int UserStatusId { get; set; }
        public virtual Event Event { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual UserStatus UserStatus { get; set; }




    }
}