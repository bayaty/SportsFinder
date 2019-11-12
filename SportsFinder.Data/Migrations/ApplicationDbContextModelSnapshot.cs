﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsFinder.Data;

namespace SportsFinder.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SportsFinder.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("GenderId");

                    b.Property<string>("Location");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SportsFinder.Data.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDate");

                    b.Property<int>("EventStatusId");

                    b.Property<int>("GenderId");

                    b.Property<string>("Location");

                    b.Property<int>("PlayersNeeded");

                    b.Property<string>("ShareLink");

                    b.Property<int>("SkillLevelId");

                    b.Property<int>("SportId");

                    b.Property<string>("Title");

                    b.HasKey("EventId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("EventStatusId");

                    b.HasIndex("GenderId");

                    b.HasIndex("SkillLevelId");

                    b.HasIndex("SportId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SportsFinder.Data.Models.EventStatus", b =>
                {
                    b.Property<int>("EventStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventStatusName");

                    b.HasKey("EventStatusId");

                    b.ToTable("EventStatuses");

                    b.HasData(
                        new
                        {
                            EventStatusId = 1,
                            EventStatusName = "Upcoming"
                        },
                        new
                        {
                            EventStatusId = 2,
                            EventStatusName = "Ongoing"
                        },
                        new
                        {
                            EventStatusId = 3,
                            EventStatusName = "Cancelled"
                        },
                        new
                        {
                            EventStatusId = 4,
                            EventStatusName = "Completed"
                        });
                });

            modelBuilder.Entity("SportsFinder.Data.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderType");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            GenderId = 1,
                            GenderType = "Male"
                        },
                        new
                        {
                            GenderId = 2,
                            GenderType = "Female"
                        },
                        new
                        {
                            GenderId = 3,
                            GenderType = "Other"
                        });
                });

            modelBuilder.Entity("SportsFinder.Data.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.Property<int>("UserStatusId");

                    b.HasKey("PlayerId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId1");

                    b.HasIndex("UserStatusId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SportsFinder.Data.Models.PreferredGender", b =>
                {
                    b.Property<int>("PreferredGenderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderType");

                    b.HasKey("PreferredGenderId");

                    b.ToTable("PreferredGenders");
                });

            modelBuilder.Entity("SportsFinder.Data.Models.SkillLevel", b =>
                {
                    b.Property<int>("SkillLevelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SkillLevelDescription");

                    b.Property<string>("SkillLevelName");

                    b.HasKey("SkillLevelId");

                    b.ToTable("SkillLevels");

                    b.HasData(
                        new
                        {
                            SkillLevelId = 1,
                            SkillLevelDescription = "New to the sport, or never played before",
                            SkillLevelName = "Beginner"
                        },
                        new
                        {
                            SkillLevelId = 2,
                            SkillLevelDescription = "Comfortable playing the sport, have a long way to go",
                            SkillLevelName = "Intermediate"
                        },
                        new
                        {
                            SkillLevelId = 3,
                            SkillLevelDescription = "High level of play, Varsity or higher",
                            SkillLevelName = "Advanced"
                        });
                });

            modelBuilder.Entity("SportsFinder.Data.Models.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SportIcon");

                    b.Property<string>("SportName");

                    b.HasKey("SportId");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            SportId = 1,
                            SportIcon = "fas fa-basketball-ball",
                            SportName = "Basketball"
                        },
                        new
                        {
                            SportId = 2,
                            SportIcon = "fas fa-baseball-ball",
                            SportName = "Baseball"
                        },
                        new
                        {
                            SportId = 3,
                            SportIcon = "fas fa-volleyball-ball",
                            SportName = "Volleyball"
                        },
                        new
                        {
                            SportId = 4,
                            SportIcon = "fas fa-football-ball",
                            SportName = "Football"
                        },
                        new
                        {
                            SportId = 5,
                            SportIcon = "far fa-futbol",
                            SportName = "Soccer"
                        },
                        new
                        {
                            SportId = 6,
                            SportIcon = "fas fa-swimmer",
                            SportName = "Swimming"
                        },
                        new
                        {
                            SportId = 7,
                            SportIcon = "fas fa-running",
                            SportName = "Jogging"
                        },
                        new
                        {
                            SportId = 8,
                            SportIcon = "fas fa-bowling-ball",
                            SportName = "Bowling"
                        },
                        new
                        {
                            SportId = 9,
                            SportIcon = "fas fa-table-tennis",
                            SportName = "Ping Pong"
                        },
                        new
                        {
                            SportId = 10,
                            SportIcon = "fas fa-hockey-puck",
                            SportName = "Hockey"
                        },
                        new
                        {
                            SportId = 11,
                            SportIcon = "fas fa-golf-ball",
                            SportName = "Golf"
                        },
                        new
                        {
                            SportId = 12,
                            SportIcon = "fas fa-biking",
                            SportName = "Cycling"
                        });
                });

            modelBuilder.Entity("SportsFinder.Data.Models.UserSport", b =>
                {
                    b.Property<int>("UserSportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SportId");

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("UserSportId");

                    b.HasIndex("SportId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserSports");
                });

            modelBuilder.Entity("SportsFinder.Data.Models.UserStatus", b =>
                {
                    b.Property<int>("UserStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserStatusType");

                    b.HasKey("UserStatusId");

                    b.ToTable("UserStatuses");

                    b.HasData(
                        new
                        {
                            UserStatusId = 1,
                            UserStatusType = "Accepted"
                        },
                        new
                        {
                            UserStatusId = 2,
                            UserStatusType = "Rejected"
                        },
                        new
                        {
                            UserStatusId = 3,
                            UserStatusType = "Left"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SportsFinder.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SportsFinder.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsFinder.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SportsFinder.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsFinder.Data.Models.ApplicationUser", b =>
                {
                    b.HasOne("SportsFinder.Data.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("SportsFinder.Data.Models.Event", b =>
                {
                    b.HasOne("SportsFinder.Data.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("SportsFinder.Data.Models.EventStatus", "EventStatus")
                        .WithMany()
                        .HasForeignKey("EventStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsFinder.Data.Models.PreferredGender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsFinder.Data.Models.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsFinder.Data.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsFinder.Data.Models.Player", b =>
                {
                    b.HasOne("SportsFinder.Data.Models.Event", "Event")
                        .WithMany("Players")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsFinder.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.HasOne("SportsFinder.Data.Models.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsFinder.Data.Models.UserSport", b =>
                {
                    b.HasOne("SportsFinder.Data.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsFinder.Data.Models.ApplicationUser", "User")
                        .WithMany("FavouriteSports")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
