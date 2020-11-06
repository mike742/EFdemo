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
            CodeFirstDbContext dbc = new CodeFirstDbContext();

            var list = dbc.Employees;

            foreach (var e in list)
            {
                string manager = (e.Manager != null) ? e.Manager.Name : "SUPER BOSS";
                
                Console.WriteLine(e.Id + " " + e.Name + " " 
                    +  manager);
            }
            
        }
    }
}
