using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFdemo
{
    class DataRepository
    {
        private CodeFirstDbContext _cfdbc = new CodeFirstDbContext();

        public void UpdateCollegeTitleById(int id, string title)
        {
            _cfdbc.Database
                .ExecuteSqlRaw($"update Colleges set title='{title}' where id = {id}");
        }

        public void InsertCollegeSp(string title, string address)
        {
            _cfdbc.Database
                .ExecuteSqlRaw("call insertCollege(@p0, @p1);",
                    parameters: new[] { title, address }
                );
        }

        public List<College> GetCollegesSP()
        {
            return _cfdbc
                .Colleges
                .FromSqlRaw("call SelectColleges()")
                .ToList();
        }

        public void AddCollege(College college)
        {
            _cfdbc.Colleges.Add(college);
            _cfdbc.SaveChanges();
        }

        public void AddColleges(List<College> colleges)
        {
            _cfdbc.AddRange(colleges);
            _cfdbc.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            _cfdbc.Students.Add(student);
            _cfdbc.SaveChanges();
        }

        public bool RemoveStudent(int id)
        {
            Student s = _cfdbc.Students.Where(s => s.Id == id).FirstOrDefault();

            if (s != null)
            {
                _cfdbc.Students.Remove(s);
                _cfdbc.SaveChanges();
                return true;
            }

            return false;
        }

        public bool EditStudent(int id, Student student)
        {
            Student s = _cfdbc.Students.FirstOrDefault(s => s.Id == id);

            if (s != null)
            {
                s.Name = student.Name;
                s.Email = student.Email;
                //s.CollegeId = student.CollegeId;

                _cfdbc.SaveChanges();
                return true;
            }

            return false;
        }

        public List<College> GetColleges()
        {
            return _cfdbc.Colleges.Include("Students").ToList();
        }
    }
}
