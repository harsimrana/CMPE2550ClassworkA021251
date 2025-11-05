<?php
    require_once './libPHP/db.php';

    
    error_log("inside index.php");
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Demo 04: Working with Database</title>
    </head>
    <body>
       <h1> Demo 04: Working with Database: DML operation</h1>

       <div>
            <?php
                $filterValue = "B";
                $myquery = "Select title_id, title, price "; 
                $myquery.= "from titles ";
                $myquery.= "where title like '%$filterValue%'";

                error_log($myquery);
                if($resultset = mysqlQuery( $myquery))
                {  // We have our result set
                    error_log("index.php if statement");
                    echo "Title_Id    | Title  <br>";
                    while($row = $resultset -> fetch_assoc()) // It will return one row at a time or false if no result left
                    {
                        echo  $row['title_id']  ." | ".   $row['title']." | ". $row['price'] ." <br>";
                    }
                }
                else
                {
                    error_log("error else part");
                    echo $mysql_response;
                }


                echo "Testing DML query";
                // Prepare your query 
               /* $myquery = "delete from Students ";
                //$myquery .= " where sid = 1 ";

                //SPECIAL NOTE:
                // For Delete/update withour where clause it will delete/update everything
                // Pattern seach 
                $myquery .= " where sname like '_a%' ";
                error_log("MyQuery : " . $myquery);

                // Run your query 
                */
                // TESTING IT with STORED PROCEDURE
                // SP Defination is here
                /*
                    Delete from Students
                    where sid = StudentId
                */
                $firstname= "Har'simranjot";

                // PHP function for espace string
                // Object oriented style
                // string = connectionObject-> real_escape_string(string)

                error_log("Before escape thing $firstname");
                // Object oriented style -- UNCOMMENT THE FOLLOWING LINE TO TEST
                //$EscapedFirstname = $mysql_connection->real_escape_string($firstname);
                // Procedural style-- UNCOMMENT THE FOLLOWING LINE TO TEST WITH Procedural style                
                $EscapedFirstname = mysqli_real_escape_string($mysql_connection, $firstname );
                
                error_log("Before escape thing $EscapedFirstname");

                

                
                $studentId= 5;
                $myquery ="call DeleteStudent($studentId)" ;// Make sure to use ' single quotes around string value
                
                $numberRowsAffected = myDMLQuery($myquery);

                echo "<br>Delete operation has affected $numberRowsAffected rows";
            ?>     
       </div>
    </body>
</html>