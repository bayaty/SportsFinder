namespace SportsFinder.Data.Models
{
    public class UserSport
    {
        public int UserSportId { get; set; }
        public int UserId { get; set; }
        public int SportId { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}