<?php
include("database.php");
include("headers.php");
session_start();
if ($_SERVER['REQUEST_METHOD'] == "POST"){
    $req = $_POST['request'];
    if ($req == 'login'){
        $email = $_POST['email'];
        $password = $_POST['password'];
        $result = $conn->query("SELECT * FROM member WHERE Email='$email' AND Password='$password'");
        if ($result->num_rows > 0){
            $msg = 'success';
        }
        else{
            $msg = 'failed';
        }
        $conn->close();
        echo json_encode(array('msg' => $msg));
    }
    if ($req == 'getCustomer'){
        $id = $_POST['ID'];
        $result = $conn->query("select * from customer where ID = $id");
        if ($result->num_rows = 1) {
            $msg = 'success';
            $row = $result;
        }
        else{
            $msg = 'failed';
            $row = null;
        }
        $conn->close();
        echo json_encode(array('msg' => $msg, 'data' => $row));
    }
    if($req == 'getSeller'){
        $id = $_POST['ID'];
        $result = $conn->query("select * from seller where ID = $id");
        if ($result->num_rows = 1) {
            $msg = 'success';
            $row = $result;
        }
        else{
            $msg = 'failed';
            $row = null;
        }
        $conn->close();
        echo json_encode(array('msg' => $msg, 'data' => $row));
    }
}
?>