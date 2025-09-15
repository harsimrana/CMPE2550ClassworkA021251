// To handle on page load stuff

$(()=>{

    console.log("On page load");

    // Bind onclick event to your button
    $("#b1").on("click", ()=>{
        console.log("Button b1 is clicked");

        MakeAjaxCall('server.php', "GET", {}, "HTML", successB1, errorHandler);
    });

    // Bind onclick event to your button b2
    $("#b2").on("click", ()=>{
        console.log("Button b2 is clicked");
        let data ={};
        data['p1Name'] = "Harsimranjot";
        data.p2Name = "Simran";
        data.action = "b2";  // To help server identity calls

        // Sending data from client and expecting HTML response
        MakeAjaxCall('server.php', "GET", data, "HTML", successB1, errorHandler);
    });


} );

// Success handler for button 1
function successB1(serverData, serverStatus)
{
    console.log(serverData);
    console.log(serverStatus);
    // Show it on actual page
    $("section").html(serverData);

}

// function error handler
function errorHandler(ajaxStatus, errorThrown)
{
    console.log(ajaxStatus);
    console.log(errorThrown);
}

// Function MakeAjaxCall is used to make ajax calls
function MakeAjaxCall(serverURL, reqMethod, clientData, serverResponseType, successHandler, errorHandler)
{
    console.log("Inside MakeAjax Call funciton");

    let ajaxOptions = {};
    ajaxOptions['url']      =   serverURL;          // Destination URL
    ajaxOptions['type']     =   reqMethod;          // GET/POST
    ajaxOptions['data']     =   clientData;         // CLIENT Data
    ajaxOptions['dataType'] =   serverResponseType; // HTML/JSON
    ajaxOptions['success']  =   successHandler;     // Callback function to handle successful case
    ajaxOptions['error']    =   errorHandler;       // Callback function to handle error
    
    // Actually making ajax call
    $.ajax(ajaxOptions);

}