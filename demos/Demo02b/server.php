<?php 
    error_log("Inside server side");


    // Sending response back to client
    //echo "<p> Hello from Server</p>";

// valdiate the method
if($_SERVER['REQUEST_METHOD'] == "GET")
{
    if(isset($_GET['action']) && $_GET['action'] == "b2")
    { // This request is from b2 button

        //echo "server response for b2";
        // Validate and clean client data
        $cleanName = trim( strip_tags( $_GET['p1Name']));
        $cleanName1 = trim( strip_tags( $_GET['p2Name']));

        error_log($cleanName);

        echo "Hello $cleanName  from server $cleanName1";
        
    }
    if(isset($_GET['action']) && $_GET['action'] == "b3")
    {
        $cleanName = trim( strip_tags( $_GET['p1Name']));
        $cleanName1 = trim( strip_tags( $_GET['p2Name']));

        error_log($cleanName);

        $turn = 2;

        $data = (object) [
            'name' => $cleanName,
            'currentScore' => 3,
            'nextTurn' => $turn
        ];
        error_log(json_encode($data));
        
        echo json_encode($data); //
        // send data back to client
        // convert the data objects into string


    }
    else{
        // Otherwise it is call from b1 
        echo "server response for b1";
    }
}
else
{
    echo "No you are not allowed. Enjoy Summer outside";
}
?>