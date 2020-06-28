using Microsoft.EntityFrameworkCore;
using SuperStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SuperStore.Infrastructure.Data
{
   public class SuperStoreContext : DbContext
    {
        public SuperStoreContext(DbContextOptions<SuperStoreContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }
    }
}
