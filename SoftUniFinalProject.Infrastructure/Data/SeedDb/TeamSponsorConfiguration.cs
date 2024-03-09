using Microsoft.EntityFrameworkCore;
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
    internal class TeamSponsorConfiguration : IEntityTypeConfiguration<TeamSponsor>
    {
        public void Configure(EntityTypeBuilder<TeamSponsor> builder)
        {
            builder.HasKey(ts => new { ts.SponsorId, ts.TeamId });
        }

        //Za dobavqne kum many to many table
        //    internal class ConfigureAuthorBook : IEntityTypeConfiguration<Book>
        //{
        //    public void Configure(EntityTypeBuilder<Book> entity)
        //    {
        //        entity
        //            .HasMany(b => b.Authors)
        //            .WithMany(a => a.Books)
        //            .UsingEntity(
        //                 ba => ba.HasData(
        //                     new { BooksBookId = 1, AuthorsAuthorId = 1 },
        //                     new { BooksBookId = 1, AuthorsAuthorId = 2 }));
        //    }
        //}
    }
}
