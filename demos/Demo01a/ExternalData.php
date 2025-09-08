<?php
    $age = 42;

    /*******************************************
     * Function: function MakeArray($quantity)
     * Purpose : To generate an array of stars
     * Inputs  : Number of elements
     * Output  : An array
     *******************************************/

    function MakeArray($quantity)
    {
        $stars = array();  // An empty array 

        for($i= 0 ; $i <= $quantity; ++$i)
        {
            $stars[] = "*";
        }
        return $stars; // Return the list back to calling location
    }
?>