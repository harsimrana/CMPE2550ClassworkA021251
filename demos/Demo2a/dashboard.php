<?php
    


    session_start(); // Create or rejoin a session

    if(isset($_SESSION['username']))
    {
        echo "Welcome to my website : ". $_SESSION['username'];

        $_SESSION['item1'] ="Book on programming";

        echo "<br>Cart: ". $_SESSION['item1'];

        echo "<br> <a href='logout.php'> Logout </a>";
    }
    else
    {
        echo " You don't have access my friend. Enjoy summer outside";
    }
?>