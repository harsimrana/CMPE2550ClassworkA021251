<?php
    //start session or rejoin session
    session_start();
    error_log("Inside Login.php");

    // Clean your data at this point
    $cleanData= array();

    if($_SERVER['REQUEST_METHOD'] == 'POST')
    {
        error_log("Inside Main Logic part POST ");
        foreach($_POST as $key=>$value)
        {
            $cleanData[ trim(strip_tags($key)) ] = trim(strip_tags( $value));  
        }

        $_SESSION['username'] = $cleanData['username'];
        
        // Write your logic to validate username password
        //Compare credential here
        
        header("Location:welcome.php"); // REdirect the user to welcome.php

    }
    
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        
        <title>Login Page Demo 05</title>
        <!-- Link to CSS -->
        <link rel="stylesheet" href="styles.css">
        
    </head>
    <body>
        <h1> Login Page</h1>
        <form action="login.php" method="POST">
            <label for="username">Username</label>
            <input type="text" name="username" placeholder="Enter Username here">

            <label for="password">Password</label>
            <input type="password" name="password" placeholder="Enter password here">
            <input type="submit" value="LOGIN">
            <input type="reset" value="Reset">
            <input type="button"  value="Register">
        </form>
    </body>
</html>