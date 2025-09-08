<?php
    require_once('ExternalData.php');
    //include('ExternalData1.php');

    // Single Line Comment
    # Single Line comment- ANother version to add single comment
    /*
        Multi Line Comments using same style we used in Javascript and C#
    */
    
    error_log("Inside index.php file");  
    // error_log - important for debugging - Your friend while debugging  same as console,log in Javascipt

    $name = "Harsimran";
    // echo statement is used to print something on screen- Just like Console.WriteLine 
    echo "Some Stuff from PHP Block";

    $number = array(3,5,7,8);

    // User defined function
    function UserData()
    {
        error_log("inside USERDATA function");
        global $name, $age;
        # to access global variables inside the function, you need to 
        #mention the scope again
        echo "<br> Inside function your name is $name";

        # or global variables can be accessed by super global array $GLOBALS

        echo "<br> Inside function your name is ". $GLOBALS['name']; 
        // Make sure to use regular concat in case of GLOBALS 

        echo "<br>Your Age = $age ";

    }
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title><?php echo "Demo 01 PHP"?></title>
    </head>
    <body>
        <h1><?php echo "Demo 01a: PHP $name"?> </h1>
        <h1><?php echo "Demo 01a: PHP ". $name?> </h1>

        <?php
            echo "<p> Value at indext position 0 in my array $number[0] </p>";

            // You can insert your varialbe directly inside your string 

            echo "<p> Value at indext position 0 in my array".  $number[0]. "</p>";
            // . (dot) is used to concat strings in PHP

            echo "<br>Your Age = $age ";
            UserData();

            // Calling function MakeArray from ExternalData.php file
            $collection = MakeArray(5);

            //echo $collection; // Not possible

            // using foreach loop print all the values

            $list =" <ul>";
            foreach($collection as $key => $value)
            {
                 $list .=" <li> $value</li>";
            }
            $list .= " </ul>";

            echo $list;

        ?>

        <footer>
           <?php
                # require_once() will include everything 
                #from the specified file into the current file
                //require_once('footer.php');
                include('footer.php');

                /*
                The only difference is that include statement
                generate PHP alert but PHP script will keep running 
                if that file is missing

                on the other hand, require_once() will generate fatal error
                and terminates the script
                
                Recommended: use require_once - ALways
                */

           ?> 
        </footer>
    </body>
</html>