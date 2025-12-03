using Week14Day02EFDemo.DBClassTrak;

namespace Week14Day02EFDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            /* EF- Entity Framework is object -relation mapper
             * Project -> Manage NuGet Packages -> Browse - Search the name of package
             * Install 7.0 version for both of these
             * 
             * Step 1. Install Package - MicroSoft.EntityFrameworkCore.SqlServer
             * Step 2. Install package - Microsoft.EntityFrameworkCore.Tools
             * 
             * Step 3. Reverse Engineering Part 
             * Scaffold-DbContext "Server=data.cnt.sast.ca,24680;Database=demouser_Classtrak;
             * User Id=demoUser;Password=temP2020#;Encrypt=False;" 
             * Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBClassTrak
             * 
             */
            app.MapGet("/", () => "Hello World!");

            app.MapGet("/RetData", () =>
            {
                Console.WriteLine("Inside RetData Endpoint");

                //Create an object of DB
                var db = new DemouserClasstrakContext();

                // LINQ Queries 
                // Query Style of LINQ query 
                //PART 1
                /* select * from students
                
                 */

                //var results = from s in db.Students
                //              join cs in db.ClassToStudents
                //                  on s.StudentId equals cs.StudentId
                //              where s.StudentId == 258          //filtering 
                //              orderby s.FirstName descending  // by default it is ascending order Type full desecending keyword for desecending
                //              //select s;  // similar to select *
                //              select new { s.LastName, s.StudentId, s.FirstName, cs };

                //return results.ToList();


                // Method Style Syntax for LINQ query

                var results = db.Students
                                 
                             //.Where(x => x.StudentId == x.ClassToStudents.)
                                  .Where(x => x.StudentId == 258)
                                 //.OrderBy(x=> x.FirstName)                                    // Ascending order
                                 .OrderByDescending(x => x.FirstName)
                                 .ThenBy(x => x.StudentId)                                        // For next sorting asc criteria

                                 //.Select(x => x);  // Select *
                                 .Select(x => new { x.StudentId, x.LastName, x.FirstName });    // selecting specific columns

                return results.ToList();


            });

            app.Run();
        }
    }
}
