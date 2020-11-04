using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFdemo
{
    class DataRepository
    {
        private CodeFirstDbContext _cfdbc = new CodeFirstDbContext();

        public void AddCollege(College college)
        {
            _cfdbc.Colleges.Add(college);
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

            if (s != null) {
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
                s.CollegeId = student.CollegeId;

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
