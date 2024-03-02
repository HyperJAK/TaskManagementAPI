using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using ClassFormWithDb.Classes;

namespace TaskManagementAPI.Classes.Database
{
    public class DatabaseLayer : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ClassFormWithDb.Classes.Task> Tasks { get; set; }

        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            optionsBuilder.UseMySQL(connectionString);
        }

    }


}
