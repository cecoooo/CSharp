﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ApplicationDBContext: DbContext
    {
        private const string _connectionString = "Server=CECO\\SQLEXPRESS;Database=MinionsDB;User Id=sa;Password=1234;TrustServerCertificate=True;";

        public DbSet<Town>? Towns { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Minions>? Minions { get; set; }
        public DbSet<Villians>? Villians { get; set; }
        public DbSet<EvilnessFactory>? EvilnessFactories { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
