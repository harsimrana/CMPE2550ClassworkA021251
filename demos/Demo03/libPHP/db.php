<?php
    $mysql_connetion = null;
    $mysql_response = "";
    $mysql_status ="";

    mysqlconnect();  // Calling function to test connection

    function mysqlconnect()
    {
        global $mysql_connetion, $mysql_response, $mysql_status;

        /*
        Database Name: aulakhha_1251_2550_A02
        Username: aulakhha_Admin2550A02
        Password: M^9RdcPngGHhlKKM
        */
        $mysql_connetion = new mysqli("localhost",              // Server Name
                                      "aulakhha_Admin2550A02", // Username
                                      "M^9RdcPngGHhlKKM",      // Password
                                      "aulakhha_1251_2550_A02");// Database Name

        if($mysql_connetion->connect_error)
        {
            $mysql_response = "Connect Error ( ". $mysql_connetion->connect_errno . ") ".
                               $mysql_connetion -> connect_error;
            error_log( json_encode($mysql_response));

        }
        else
        {
            //echo "Connection Successfull";
            error_log("Connection successfully ");
        }                              

    }

?>