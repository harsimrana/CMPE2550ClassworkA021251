<?php 
    error_log("Inside server side");


    // Sending response back to client
    //echo "<p> Hello from Server</p>";

    if(isset($_GET['action']) && $_GET['action'] == "b2")
    { // This request is from b2 button

        echo "server response for b2";
    }
    else{
        // Otherwise it is call from b1 
        echo "server response for b1";
    }

?>