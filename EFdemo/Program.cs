using System;
using System.Linq;

namespace EFdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository dr = new DataRepository();

            //dr.AddCollege( new College { Id = 101, Title ="Robertson", Address ="Winnipeg" } );
            // dr.AddCollege( new College { Id = 102, Title ="Red River", Address ="Winnipeg" } );

            // dr.AddStudent( new Student { Name = "Mark", Email = "mark@gmail.com", CollegeId = 101} );
            // dr.AddStudent( new Student { Name = "Rosy", Email = "rosy@gmail.com", CollegeId = 101} );

            // dr.AddStudent( new Student { Name = "Todd", Email = "toddd@gmail.com", CollegeId = 102} );


            // dr.RemoveStudent(3);
            dr.EditStudent(1, new Student { Name = "Mike", Email = "mike@gmail.com", CollegeId = 102 });

            var list = dr.GetColleges();

            // list.ForEach(c => Console.WriteLine(c.Title));

            foreach (var c in list)
            {
                Console.WriteLine(c.Title);
                foreach (var s in c.Students)
                {
                    Console.WriteLine("\t" + s.Id + " " + s.Name);
                }
            }

        }
    }
}
