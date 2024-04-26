using AnualLists.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AnualLists.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<WineModel> Wine { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "AnualLists.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectModel>().Property(e => e.Id).ValueGeneratedOnAdd();

            var subject = new SubjectModel()
            {
                Id = 1,
                Year = 2020,
                Subject_name = "Math",
                Synopsis = "Synopsis for math_2020"
            };
            modelBuilder.Entity<SubjectModel>().HasData(subject);
            var subject2 = new SubjectModel()
            {
                Id = 2,
                Year = 2020,
                Subject_name = "Math",
                Synopsis = "Synopsis for math_2020_v2"
            };
            modelBuilder.Entity<SubjectModel>().HasData(subject2);
            var subject3 = new SubjectModel()
            {
                Id = 3,
                Year = 2020,
                Subject_name = "English",
                Synopsis = "Synopsis for english_2020"
            };
            modelBuilder.Entity<SubjectModel>().HasData(subject3);
            var subject4 = new SubjectModel()
            {
                Id = 4,
                Year = 2020,
                Subject_name = "IT",
                Synopsis = "Synopsis for it_2020"
            };
            modelBuilder.Entity<SubjectModel>().HasData(subject4);
            var subject5 = new SubjectModel()
            {
                Id = 5,
                Year = 2018,
                Subject_name = "English",
                Synopsis = "Synopsis for english_2018"
            };
            modelBuilder.Entity<SubjectModel>().HasData(subject5);
            var subject6 = new SubjectModel()
            {
                Id = 6,
                Year = 2030,
                Subject_name = "Math",
                Synopsis = "Synopsis for math_2018"
            };
            modelBuilder.Entity<SubjectModel>().HasData(subject6);

            modelBuilder.Entity<WineModel>().Property(e => e.Id).ValueGeneratedOnAdd();
            var wine = new WineModel()
            {
                Id = 1,
                Year = 2008,
                Name = "Zelanos",
                Variety = "Sira",
                Vineyard = "Shumen",
                ProductionSize = "1000 bottles"
            };
            modelBuilder.Entity<WineModel>().HasData(wine);
            var wine2 = new WineModel()
            {
                Id = 2,
                Year = 2012,
                Name = "Zelanos",
                Variety = "Sira",
                Vineyard = "Shumen",
                ProductionSize = "500 bottles"
            };
            modelBuilder.Entity<WineModel>().HasData(wine2);
            var wine3 = new WineModel()
            {
                Id = 3,
                Year = 2008,
                Name = "Four Seasons",
                Variety = "Sparkling wine",
                Vineyard = "Plovdiv",
                ProductionSize = "1000 bottles"
            };
            modelBuilder.Entity<WineModel>().HasData(wine3);
            var wine4 = new WineModel()
            {
                Id = 4,
                Year = 2020,
                Name = "Four Seasons",
                Variety = "Sparkling wine",
                Vineyard = "Plovdiv",
                ProductionSize = "1500 bottles"
            };
            modelBuilder.Entity<WineModel>().HasData(wine4);
            var wine5 = new WineModel()
            {
                Id = 5,
                Year = 2020,
                Name = "Four Seasons",
                Variety = "Sparkling wine",
                Vineyard = "Melnik",
                ProductionSize = "400 bottles"
            };
            modelBuilder.Entity<WineModel>().HasData(wine5);
        }
    }
}
