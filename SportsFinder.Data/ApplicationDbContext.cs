using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsFinder.Data.Models;

namespace SportsFinder.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventStatus> EventStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PreferredGender> PreferredGenders { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<UserSport> UserSports { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        //public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region SeedDatabase
            //
            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, GenderType = "Male" },
                new Gender { GenderId = 2, GenderType = "Female" },
                new Gender { GenderId = 3, GenderType = "Other" }

            );
            modelBuilder.Entity<EventStatus>().HasData(
                new EventStatus {  EventStatusId=1, EventStatusName="Upcoming"},
                new EventStatus {  EventStatusId=2, EventStatusName="Ongoing"},
                new EventStatus {  EventStatusId=3, EventStatusName="Cancelled"},
                new EventStatus {  EventStatusId=4, EventStatusName="Completed"}

            );
            modelBuilder.Entity<Sport>().HasData(
                new Sport {  SportId=1,SportIcon= "fas fa-basketball-ball",SportName="Basketball"},
                new Sport {  SportId=2,SportIcon= "fas fa-baseball-ball", SportName="Baseball"},
                new Sport {  SportId=3,SportIcon="fas fa-volleyball-ball",SportName="Volleyball"},
                new Sport {  SportId=4,SportIcon= "fas fa-football-ball",SportName= "Football" },
                new Sport {  SportId=5,SportIcon= "far fa-futbol",SportName= "Soccer" },
                new Sport {  SportId=6,SportIcon= "fas fa-swimmer",SportName="Swimming"},
                new Sport {  SportId=7,SportIcon= "fas fa-running", SportName="Jogging"},
                new Sport {  SportId=8,SportIcon= "fas fa-bowling-ball", SportName="Bowling"},
                new Sport {  SportId=9,SportIcon= "fas fa-table-tennis", SportName= "Ping Pong" },
                new Sport {  SportId=10,SportIcon= "fas fa-hockey-puck", SportName= "Hockey" },
                new Sport {  SportId=11,SportIcon= "fas fa-golf-ball",SportName= "Golf" },
                new Sport {  SportId=12,SportIcon= "fas fa-biking",SportName= "Cycling" }



            );
            modelBuilder.Entity<UserStatus>().HasData(
                new UserStatus {  UserStatusId=1, UserStatusType="Accepted"},
                new UserStatus {  UserStatusId=2, UserStatusType="Rejected" },
                new UserStatus {  UserStatusId=3, UserStatusType="Left" }

            );
            //test code that will probably be removed later (specific events, etc)
            modelBuilder.Entity<SkillLevel>().HasData(
                new SkillLevel {  SkillLevelId =1, SkillLevelName="Beginner", SkillLevelDescription="New to the sport, or never played before"},
                new SkillLevel {
                    SkillLevelId = 2,
                    SkillLevelName = "Intermediate",
                    SkillLevelDescription = "Comfortable playing the sport, have a long way to go"},
                new SkillLevel {
                    SkillLevelId = 3,
                    SkillLevelName = "Advanced",
                    SkillLevelDescription = "High level of play, Varsity or higher" }

            );

           

            #endregion

        }

    }
}