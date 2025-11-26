using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Transactions;

namespace ASPADODemoProject
{
    public class Program
    {
        /*
         * ADO: ActiveX Data Object: Microsoft technology for
         * accessing and manipulating data from a database SQL SERVER 
         * 
         * To use this one need to install package 
         */

        /**************************************************
         * Function Name        :   CleanInput
         * Purpose              :   To sanitize inputs
         * Input                :   string
         * Output               :   string - cleaned string
         * 
         * ************************************************/
        public static string CleanInput(string input)
        {
            // clean your inputs here
            string cleanInput = Regex.Replace( input.Trim(), "<.*?>|&.*?;" , string.Empty );

            //   tags and entities
            //   . one character 
            //   *  0 or more previous character
            //   |  - or package 
            //   ?   Lazy matching to the end of tag: perfect for tap striping
            return cleanInput;
            // Regex expression can be used 
            // Replace(string to be cleaned,  pattern to remove,  string.Empty)

        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Define your connection string 
            string connectionString = "Server=data.cnt.sast.ca,24680;" +
                                      "Database=demoUser_ClassTrak;" +
                                      "User Id = demoUser;" +
                                      "Password=temP2020#;" +
                                      // for local testing it is fine, not for production 
                                      //"Encrypt=false;";  // Not good not recommened  because I want my data to be encrypted
                                      "Encrypt=true;" +  // force the SQL connection to use TLS encryption 
                                                         // protect the data in transit
                                                         // Required by Cloud platforms like Azure, AWS, GOOGLE
                                      "TrustServerCertificate=True;";
                                    // If you are installed database server locally 
                                    // then it is not going to work because mostly TLS certificate is not present/installed


            app.MapGet("/", () => "ASP ADO Demo 01");


            // End point to retrieve data from student database
            app.MapGet("/RetriveData", () =>
            {
                Console.WriteLine("Inside Ret Data part");
                try  // Try to do everything inside try catch block to handle exceptions nicely
                {
                    // Step 1: Establish the connection to Database
                    // Use SQLConnection  class to do that
                    SqlConnection connection = new SqlConnection(connectionString);

                    // Step 2: Open the connection 
                    connection.Open(); // open the connection
                    Console.WriteLine("Connection is open now");

                    // Step 3: Prepare your query
                    string query = "select * from Students";

                    Console.WriteLine(query);

                    // Step 4: Execute your query
                    // SqlCommand class is required to run your query

                    SqlCommand command = new SqlCommand(query, connection);

                    // Step 5 : Run your query Iterate through the result set

                    SqlDataReader reader = command.ExecuteReader();  // Is for retrieval query 
                                                                     //
                    while(reader.Read()) // false if no data or end of data set
                    { // One record at a time
                        Console.WriteLine($" {reader["student_id"]} {reader.GetString(2)} ");
                        //You have data, you can return it back to user using JSON Object or string
                        // List, Class, Array , Dictionary 


                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error"+ ex.Message);
                }
            });

            //26.11.2025: ADO Demo part 2 : DML Operations
            // End points for manaing delete operation
            // Make sure to follow REST methods: GET,    POST   , DELETE, PUT
            // Retrieve, Insert, Delete, Update

            app.MapGet("/DeleteEmployee", () =>
            {
                Console.WriteLine("Inside Delete Emp");
                SqlTransaction transaction;
                // Trying to get connection information from appsettings.json file 
                SqlConnection con = new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection") );

                con.Open();

                // Start a new transaction
                transaction = con.BeginTransaction();
                try
                {
                    // Prepare our query here
                    string query = "Delete from students where student_id= @sid";

                    SqlCommand command = new SqlCommand(query, con, transaction);

                    // Hard coded values, cahnge it to value coming from client side
                    // Binding the parameter with the value
                    command.Parameters.AddWithValue("@sid", 200350559);

                    // Execute your query
                    // ExecuteNonQuery() -- return the number of rows affected

                    int rowsAffected = command.ExecuteNonQuery();
                    // For DML queries [Data manipulation Language]

                    transaction.Commit(); // Save the changes in the DB
                    Console.WriteLine($" Number of students deleted {rowsAffected}");
                    return $" Number of students deleted {rowsAffected}";

                }
                catch (Exception e)
                {
                    // Something goes wrong : time to rollback
                    transaction.Rollback();

                    Console.WriteLine("Error" + e.Message);
                    return $" Error: Try after sometime or contact Admin";
                }

            });
            app.Run();
        }
    }
}
