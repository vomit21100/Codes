<?php
    $url='localhost';   // DB Address
    $username='root';   // DB Account
    $password='gran21100';       // DB Password
    $dbName='shopmee';    // DB Name
    $conn=mysqli_connect($url, $username, $password, $dbName);
    if(!$conn){
        // faile
        die("Could not Connect to {$dbName}");
    }else {
        // success
        $conn->set_charset("UTF8");
    }
?>