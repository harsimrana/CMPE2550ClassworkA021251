<?php
    session_start();
    if(!isset($_SESSION['username']))
    {
        echo "You are not authorized to visit page";
        echo "<a href='login.php'> Please click here to login</a>";

        require_once('login.php');
        die();
        
    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Welcome Page</title>
    </head>
    <body>
        <h1> Welcome <?php  echo $_SESSION['username']; ?></h1>
        <!-- Link to provide Logout option  -->
        <a href="logout.php"> Logout </a>
    </body>
</html>