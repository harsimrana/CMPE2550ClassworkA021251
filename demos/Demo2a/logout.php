<?php

    // Join the session
    session_start();

    // Remove all the session variables
    session_unset();

    // it will destroy the session
    session_destroy();

    header('Location:login.php');
    exit();  // Terminates the remaining part of the script
?>