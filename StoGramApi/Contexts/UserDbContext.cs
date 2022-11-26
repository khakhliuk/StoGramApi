using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoGramApi.Models;

namespace StoGramApi.Contexts
{
    public class UserDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public UserDbContext(IConfiguration config)
        {
            Configuration = config;
            Database.EnsureCreated();
            //File.Delete("Users.db");
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>();
            modelBuilder.Entity<PostModel>();
        }
    }
}
