namespace Week08d3Demo01Asp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("For debugging purpose");
            // WebApplication is a special class provided by Microsoft:
            // used to configure the HTTP pipeline and routes

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

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
            app.Run();
        }
    }
}
