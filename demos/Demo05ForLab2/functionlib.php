<?php
    // hashing the password

    //password_hash(actual password, EncrytionAlgo);
    // Used to create a password hash so that you can store encrypted version of 
    // password in the database.
    $clientPassword = "simran1234";

    error_log("Before Ency: $clientPassword");
    $secretPassword = password_hash( $clientPassword, PASSWORD_DEFAULT);

    error_log("After Ency: $secretPassword ");

    // Function to check valid credentials
    function LoginCheck($user, $pass)
    {
        global $secretPassword;
                            // password_verify(actualPassword, encrypted one stored in DB)
        if($user=="simran" && password_verify($pass, $secretPassword))
        { // Hardcoding username for demo purpose
            return true;

        }
        return false;
    }
?>