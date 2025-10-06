<?php
    $mysql_connection = null;
    $mysql_response = "";
    $mysql_status ="";

    mysqlconnect();  // Calling function to test connection
    /***********************************************************
     * mysqlconnect(): Establish connection to DB
     * Inputs        : N/a
     * Output        : n/a [error log]
     ***********************************************************/

    function mysqlconnect()
    {
        global $mysql_connection, $mysql_response, $mysql_status;

        /*
        Database Name: aulakhha_1251_2550_A02
        Username: aulakhha_Admin2550A02
        Password: M^9RdcPngGHhlKKM
        */
        //mysqli(): will connect to DB and return connection information
        $mysql_connection = new mysqli("localhost",              // Server Name
                                      "aulakhha_Admin2550A02", // Username
                                      "M^9RdcPngGHhlKKM",      // Password : Make sure there is no . in your password
                                      "aulakhha_1251_2550_A02");// Database Name

        if($mysql_connection->connect_error)
        {
            $mysql_response = "Connect Error ( ". $mysql_connection->connect_errno . ") ".
                               $mysql_connection -> connect_error;
            error_log( json_encode($mysql_response));

        }
        else
        {
            //echo "Connection Successfull";
            error_log("Connection successfully ");
        }                              

    }

    /*********************************************
     *  mysqlQuery() :  To execute your select queries
     *  Inputs       :  Query [string]
     *  Output       :  Result set or false
     *********************************************/
    function mysqlQuery( $query )
    {
       global $mysql_connection, $mysql_response, $mysql_status;
       
       $result = false;

       // Checking the connection
       if($mysql_connection == null)
       {
            error_log("No database connection");

            $mysql_response = "No database connection";
            return $result;

       }
       // Run the query 
       // query function will return result set or false
       else if( !($result = $mysql_connection -> query( $query )) ) // query function will execute your query
       {
            $mysql_response = " Query Error { $mysql_connection->errno } : {$mysql_connection ->error} ";
       }

       return $result; 
    }

  /*********************************************
     *  myDMLQuery() :  To execute your DML queries [Data Manipulation Language] [Insert, Update and Delete]
     *  Inputs       :  Query [string]
     *  Output       :  Number of rows affected
     *********************************************/
    function myDMLQuery($myDMLQuery)
    {
        global $mysql_connection, $mysql_response, $mysql_status;

        if($mysql_connection == null)
        {
            error_log("No Active connection");
            $mysql_response = "No database connection";
            return 0;
        }

        if( !($mysql_connection->query($myDMLQuery)))
        {
            error_log("Error while executing query");
            $mysql_response= "Query Error : { $mysql_connection->errno} : {$mysql_connection->error} ";
            
        }
        
        //All Good return the rows affected value back to calling point
        return $mysql_connection-> affected_rows; // How many rows are affected by the last query 
    }

?>