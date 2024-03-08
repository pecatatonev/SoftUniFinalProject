﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftUniFinalProject.Infrastructure.Data;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Comment Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasComment("Event Identifier");

                    b.Property<DateTime>("PublicationTime")
                        .HasColumnType("datetime2")
                        .HasComment("The publication time of the comment");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Text of the comment");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Creator of the comment Identifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Event Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Event Description");

                    b.Property<int>("FootballGameId")
                        .HasColumnType("int")
                        .HasComment("Football game Identifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Event Location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Event Name");

                    b.Property<string>("OrganiserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Organiser Identifier");

                    b.Property<DateTime>("StartOn")
                        .HasColumnType("datetime2")
                        .HasComment("Start of the event");

                    b.HasKey("Id");

                    b.HasIndex("FootballGameId");

                    b.HasIndex("OrganiserId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.EventParticipant", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventParticipant");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.FootballGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Football Game Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int")
                        .HasComment("Football Game Away Team Identifier");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int")
                        .HasComment("Football Game Home Team Identifier");

                    b.Property<string>("PlayingFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Reason for the game");

                    b.Property<string>("RefereeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Referee of the match name");

                    b.Property<DateTime>("StartGame")
                        .HasColumnType("datetime2")
                        .HasComment("Start of the game");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId")
                        .IsUnique();

                    b.HasIndex("HomeTeamId")
                        .IsUnique();

                    b.ToTable("FootballGame");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Sponsor Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Logo of the sponsor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Sponsor Name");

                    b.Property<int>("NetWorthInBillion")
                        .HasColumnType("int")
                        .HasComment("Sponsor NetWorth");

                    b.Property<DateTime>("StartOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date of creation");

                    b.HasKey("Id");

                    b.ToTable("Sponsor");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Team Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Team logo");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Manager of the team");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasComment("Team Name");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Team Nickname");

                    b.Property<int>("StadiumCapacity")
                        .HasColumnType("int")
                        .HasComment("Stadium Capacity");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasComment("Team Stadium Name");

                    b.Property<DateTime>("YearCreated")
                        .HasColumnType("datetime2")
                        .HasComment("Year of creation");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.TeamSponsor", b =>
                {
                    b.Property<int>("SponsorId")
                        .HasColumnType("int")
                        .HasComment("Team Sponsor Identifier");

                    b.Property<int>("TeamId")
                        .HasColumnType("int")
                        .HasComment("Team Identifier");

                    b.HasKey("SponsorId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamSponsor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("SoftUniFinalProject.Infrastructure.Data.Models.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Event", b =>
                {
                    b.HasOne("SoftUniFinalProject.Infrastructure.Data.Models.FootballGame", "FootballGame")
                        .WithMany()
                        .HasForeignKey("FootballGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Organiser")
                        .WithMany()
                        .HasForeignKey("OrganiserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FootballGame");

                    b.Navigation("Organiser");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.EventParticipant", b =>
                {
                    b.HasOne("SoftUniFinalProject.Infrastructure.Data.Models.Event", "Event")
                        .WithMany("EventParticipants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.FootballGame", b =>
                {
                    b.HasOne("SoftUniFinalProject.Infrastructure.Data.Models.Team", "AwayTeam")
                        .WithOne()
                        .HasForeignKey("SoftUniFinalProject.Infrastructure.Data.Models.FootballGame", "AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SoftUniFinalProject.Infrastructure.Data.Models.Team", "HomeTeam")
                        .WithOne()
                        .HasForeignKey("SoftUniFinalProject.Infrastructure.Data.Models.FootballGame", "HomeTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.TeamSponsor", b =>
                {
                    b.HasOne("SoftUniFinalProject.Infrastructure.Data.Models.Sponsor", "Sponsor")
                        .WithMany("TeamsSponsors")
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftUniFinalProject.Infrastructure.Data.Models.Team", "Team")
                        .WithMany("TeamsSponsors")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sponsor");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Event", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("EventParticipants");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Sponsor", b =>
                {
                    b.Navigation("TeamsSponsors");
                });

            modelBuilder.Entity("SoftUniFinalProject.Infrastructure.Data.Models.Team", b =>
                {
                    b.Navigation("TeamsSponsors");
                });
#pragma warning restore 612, 618
        }
    }
}
