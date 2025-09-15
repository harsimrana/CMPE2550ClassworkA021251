<?php

    error_log('inside login');
    // SERVER side stuff
    // Process your form here
    if($_SERVER['REQUEST_METHOD'] =="POST")
    {
        error_log('inside if ');
        // Validate your username and password
        // Start a new session or join a session if there is a session already
       
        session_start();

        // Session variable to maintain username;
        $_SESSION['username'] = trim (strip_tags( $_GET['username']) ); // clean value

        echo $_SESSION['username'];
        // Logic to verify username and password

        //header('Location:dashboard.php');  // Redirecting the user to dashboard.php page

    }
    else{
        error_log('inside else');
        echo "else";
    }

    error_log('after if else');

?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Login Page</title>
    </head>
    <body>
        <h1> Week 02 Day 02: Demo 02 A: Sessions</h1>
        
        <form action="login.php" method="POST">
            <label for=""> Username</label>
            <input type="text" required name="username">

            <input type="submit" name="submit" value="Login">
            <?php
                echo "<br>Cart : ". $_SESSION['item1'];
            ?>



        </form>
    </body>
</html>