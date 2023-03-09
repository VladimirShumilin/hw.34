using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVS.Data.Models;

namespace WebApiVS.Data
{
    public sealed class HomeApiContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }

        public HomeApiContext(DbContextOptions<HomeApiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Room>().ToTable("Rooms");
            builder.Entity<Device>().ToTable("Devices");
        }
    }
}
