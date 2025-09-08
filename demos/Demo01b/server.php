<?php
error_log("Inside server.php");
// Step 01 : Validation: Validate the data and request coming from client side

/*
    isset() : funciton checks whether or not a varaible is set
    which means it has to be declared and is not null
    Return : true/ false
*/

if( isset($_GET['username']) && strlen($_GET['username']) > 0
    && isset($_GET['userage']) && strlen($_GET['userage']) > 0)  // valdiation
{
    // Step 2: Sanitize your inputs
    
    /*
        Need to sanitize your data received from client side
        trim()      - clean white spaces from both ends of the input
        strip_tags()- strip a string from HTML, XML, PHP or tags

        use strip_tags first then use trim function
    */
    
    error_log("Before cleaning data: " . $_GET['username']);
    // SUPER Global Array $_GET or $_POST
    // User name field as index to target specfic field value

    // stt is a user defined function defined at the end of this file
    // Don't search on GOOGLE
    $cleanUserName = stt($_GET['username']) ;
    $cleanUserAge  = stt($_GET['userage']);

    error_log("After cleaning data: " . $cleanUserName);

    echo "<br>Welcome to Server Side";
    echo "<br> User Details:";
    echo "<br> User Name :  $cleanUserName" ;
    echo "<br> User Age : ". $cleanUserAge;  // Second style with dot
}
else
{ // Valdiation fails
    echo "Sorry you are not allowed. Enjoy the summer outside! ";
}

/***********************************
 * stt   :   To clean input
 * input :   string
 * output:   Cleaned string
 * **********************************/

function stt($input)
{
    return trim( strip_tags($input) );
}
?>