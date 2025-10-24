<?php
    session_start();  // Rejoin

    session_unset();  // Unset all the session variables

    session_destroy(); // Destroy your session

    header("Location:login.php");
?>