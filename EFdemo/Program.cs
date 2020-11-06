using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository dr = new DataRepository();

            //dr.AddCollege( new College { Id = 101, Title ="Robertson", Address ="Winnipeg" } );
            //dr.AddCollege( new College { Id = 102, Title ="Red River", Address ="Winnipeg" } );
            //dr.AddCollege( new College { Id = 103, Title ="MITT", Address ="Winnipeg" } );

            // dr.AddStudent( new Student { Name = "Mark", Email = "mark@gmail.com", CollegeId = 101} );
            // dr.AddStudent( new Student { Name = "Rosy", Email = "rosy@gmail.com", CollegeId = 101} );

            // dr.AddStudent( new Student { Name = "Todd", Email = "toddd@gmail.com", CollegeId = 102} );


            // dr.RemoveStudent(3);
            // dr.EditStudent(1, new Student { Name = "Mike", Email = "mike@gmail.com"});

            // var list = dr.GetColleges();
            //dr.InsertCollegeSp("Title for SP", "Address for SP");
            
            dr.UpdateCollegeTitleById(104, "New Perfect Title");
            
            var list = dr.GetCollegesSP();
            // list.Distinct();
            // list.ForEach(c => Console.WriteLine(c.Title));

            

            foreach (var c in list)
            {
                Console.WriteLine(c.Title);
                //foreach (var s in c.Students)
                //{
                //    Console.WriteLine("\t" + s.Id + " " + s.Name);
                //}
            }

        }
    }
}
