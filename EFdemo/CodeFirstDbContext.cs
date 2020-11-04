using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFdemo
{
    public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public int CollegeId { set; get; }

        public College College { get; set; }
    }

    public class College
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Address { set; get; }

        public List<Student> Students { set; get; }
    }

    public class CodeFirstDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<College> Colleges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=;database=codeFirstDb");
        }
    }
}
