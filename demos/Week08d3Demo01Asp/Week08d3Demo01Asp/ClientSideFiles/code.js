// JS file - Demo 01 ASP- Harsimranjot
let baseURL= "https://localhost:7206";
$().ready(()=>{
    console.log("On page load");

    $("[name=submitPost]").click( ()=>{
        // prepare and make your ajax call
        console.log("Submit Post is clicked");

        let data = {};
        data.postusername = $("[name=usernamePost]").val();
        data.postpassword = $("[name=passwordPost]").val();

        console.log(data);
        // Testing for HTML response

        //MakeAjaxCall(baseURL+"/loginPagePost",data, "HTML", "POST", SuccessPost, ErrorHandler );
        // Tesing for JSON response
        MakeAjaxCall(baseURL+"/loginPagePost",data, "JSON", "POST", SuccessPost, ErrorHandler );

    });
    
})

// success handler function for post login request
function SuccessPost(serverData, serverStatus)
{
    console.log(serverData);
}

// Error Handler function for all ajax calls
function ErrorHandler(ajres, status, errorThrown)
{

}
// Fucntion for making ajax call
function MakeAjaxCall (serverURL, data, serverResponse, reqMethod, succHandler, errorHandler)
{
    console.log("Inside make Ajax call funciton");

    let ajOptions= {};
    ajOptions['url']    = serverURL;           // Destination URL
    ajOptions.type      = reqMethod;           // GET/POST
    ajOptions.data      = JSON.stringify(data);// Client data - New for ASP Part
    ajOptions.dataType  = serverResponse;      // HTML/JSON
    ajOptions.success   = succHandler;         // Callback function to handle success case
    ajOptions.error     = errorHandler;        // Callback function to handle error
    
    ajOptions.contentType= "application/json";  // NEW for ASP Part
    //actually making ajax call
    $.ajax(ajOptions);

}