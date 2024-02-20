using CqrsTemplate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CqrsTemplate.Entities
{
    public class UsersContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<User> Users { get; set; }

        public UsersContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "CqrsTemplate.db");
        }

        // Configure auditing later

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}