using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }

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
            //Primary keys
            modelBuilder.Entity<User>()
                .HasKey(user => user.Username);
            modelBuilder.Entity<Conversation>()
                .HasKey(conv => conv.Id);
            modelBuilder.Entity<Message>()
                .HasKey(message => message.Id);
            //Primary keys
            //Konvertuojam masyvą į vieną string
            modelBuilder.Entity<Conversation>()
                .Property(conv => conv.Users)
                .HasConversion(
                new ValueConverter<List<string>, string>(
                    array => string.Join(";", array),
                    value => new List<string>(value.Split(';'))
                    )
                );
        }
    }
}
