using Microsoft.EntityFrameworkCore;
using StudyBuddyShared.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudyBuddyApp.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        private string _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.sqlite");

        public DatabaseContext()
        {

        }

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Username);
        }
    }
}
