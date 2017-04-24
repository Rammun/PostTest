using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    }
}
