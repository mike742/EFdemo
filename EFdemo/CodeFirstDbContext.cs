using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFdemo
{
    //[Table("tblStudents")]
    public class Student
    {
        public int Id { set; get; }
        //[Column("StudentName")]
        public string Name { set; get; }
        public string Email { set; get; }
        public int CollegeId { set; get; }
        public string Address { set; get; }
        
        //[ForeignKey("CollegeId")]
        public College College { get; set; }

        public List<StudentSubject> StudentSubjects { set; get; }
    }

    public class Subject
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public List<StudentSubject> StudentSubjects { set; get; }

    }
    public class StudentSubject
    {
        //public int Id { set; get; }
        public int StudentId { set; get; }
        public int SubjectId { set; get; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }

    public class College
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Address { set; get; }

        public List<Student> Students { set; get; }
    }


    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int? ManagerId { set; get; }
        public Employee Manager { set; get; }
    }

    

    public class CodeFirstDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>()
                .HasKey(st => new { st.StudentId, st.SubjectId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=;database=codeFirstDb");
        }
    }
}
