namespace Week08d3Demo01Asp
{
    public class Program
    {
        record class CleintData(string postusername, string postpassword);
        // class keyword is optional here
        public static void Main(string[] args)
        {
            Console.WriteLine("For debugging purpose");
            // WebApplication is a special class provided by Microsoft:
            // used to configure the HTTP pipeline and routes

            //CORS- Cross Origin Resource Sharing 
            /* HTTP header which is going to allow web page request to be accessed from any origin.
             */
            var builder = WebApplication.CreateBuilder(args);
            // FOR CORS issue
            builder.Services.AddControllers();

            var app = builder.Build();
            // Without CORS services will fail upon attempted activation/ missing addCors internal exception
            // Need to fix CORS problem encountered with POST AJax call

            app.UseCors(x => x.AllowAnyMethod()
                              .AllowAnyHeader()
                              .SetIsOriginAllowed(ordin => true));
            
            // Default end point  
            app.MapGet("/", () => "Hello World!");

            // Specific end points 
            app.MapGet("/newGame", () => " New game part will be handled here");


            // Specific end point for processing form
            //app.MapGet("/loginPage", (string password, string userName) => $"Form will be processed here. Welcome  {userName} Password: { password}");

            // I need more flexibility with the stuff I can do on server
            app.MapGet("/loginPage", (string password, string userName) => {
                // valdiation or cleaning part
                if (userName.Length == 0)
                {
                    return $" Sorry username is empty";
                }
                else
                {
                    return $" Welcome {userName} your password is {password}";
                }
            });

            // Specific end point for processing form
            // one would think that passing for POST would be the same as the GET, one might be wrong X
            // Need ajax call
            // It will automatically bind those properties 
            app.MapPost("/loginPagePost", (CleintData cl) => {
                Console.WriteLine("Inside LoginPagePost end point");
                // valdiation or cleaning part
                
                if (cl.postusername.Length == 0)
                {    // Uncomment the following to test with HTML response
                    //return $" Sorry username is empty";
                    var response = new
                    {
                        status = "error",
                        message = "User name is empty"
                    };
                    return response;
                }
                else
                {
                    var response = new
                    {
                        status = "success",
                        message = $" Welcome {cl.postusername} your password is {cl.postpassword}"
                    };
                    return response;
                    // Uncomment the following to test with HTML response
                    // return $" Welcome {cl.postusername} your password is {cl.postpassword}";
                }
            });

            app.Run();
        }
    }
}
