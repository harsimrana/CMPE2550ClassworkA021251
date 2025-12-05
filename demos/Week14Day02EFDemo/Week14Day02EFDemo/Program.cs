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

            app.MapGet("/AddStudent", () =>
            {
                Console.WriteLine("Inside Add student part");

                // Create an object of Student Class
                Student newStudent = new Student();

                // Populate the values for required properties
                newStudent.FirstName = "Shane";
                newStudent.LastName = "Kelemen";
                newStudent.SchoolId = 12347;

                try
                {
                    var db = new DemouserClasstrakContext();

                    // using Add method you can add new object into the students list

                    db.Students.Add(newStudent);

                    // Save the changes in the DB
                    db.SaveChanges(); // Commit

                    return $"New student with id {newStudent.StudentId} is inserted successfully in the DB";
                }
                catch (Exception e)
                {
                    return "Error " + e.Message;
                }

            });

            // Try to delete student 259 : change the id for testing
            app.MapGet("/DeleteStudent/{sid}", (string sid ) =>
            {
                Console.WriteLine($"Inside Delete handler {sid}");

                try
                {
                
                    int id = int.Parse(sid);  // converting the value to int type

                    var db = new DemouserClasstrakContext();

                    // Try to delete Student from db

                    if (db.Students.Find(id) is Student s)
                    {  // we found a match it will return an object 
                        
                        // Remove that object from LIST Students

                        db.Students.Remove(s);

                        db.SaveChanges(); // Save the changes in the database as well

                        return $" Student with id {id} has been removed";
                        
                        /*
                        // For update part make changes in the object and then update it
                        s.FirstName = "Simran";
                        s.LastName = "Aulakh";

                        db.Students.Update(s);

                        db.SaveChanges();

                        return $" Student with id {id} has been updated";
                        */
                    }
                    else
                    {
                        return "No such student in the db make sure your student id is correct";
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while performing delete operation" + e.Message);
                    return "Error while performing delete operation " + e.Message;
                }
                    

            });
            app.Run();
        }
    }
}
