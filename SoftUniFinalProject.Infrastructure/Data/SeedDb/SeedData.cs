﻿using Microsoft.AspNetCore.Identity;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser HostUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public Sponsor Sponsor { get; set; }
        private void SeedUsers() 
        {
            var hasher = new PasswordHasher<IdentityUser>();

            HostUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "host@football.com",
                NormalizedUserName = "host@football.com",
                Email = "host@football.com",
                NormalizedEmail = "host@football.com"
            };

            HostUser.PasswordHash = hasher.HashPassword(HostUser, "host123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                UserName = "guest@football.com",
                NormalizedUserName = "guest@football.com",
                Email = "guest@football.com",
                NormalizedEmail = "guest@football.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest987");
        }

        private void SeeedSponsor() 
        {
            Sponsor = new Sponsor()
            {
                Name = "Addidas",
                NetWorthInBillion = 5,
                StartOn = DateTime.Now.AddYears(-20),
            };
        }

    }
}
