using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PostTest.Core.Entities;

namespace PostTest.Core.Data
{
    public class PostDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Parcel> Parcels { get; set; }

        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Member>()
                .HasMany(x => x.Received)
                .WithOne(x => x.Recipient)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Member>()
                .HasMany(x => x.Send)
                .WithOne(x => x.Sender)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
