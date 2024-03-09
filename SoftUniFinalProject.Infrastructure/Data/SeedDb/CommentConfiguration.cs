﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Data.SeedDb
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(c => c.Event)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            var data =new SeedData();

            builder.HasData(new Comment[] { data.CommentGuest });
        }
    }
}
