<?php
include("database.php");
include("headers.php");
if($_SERVER['REQUEST_METHOD'] == "POST"){
    $req = $_POST['request'];
    if($req == 'offproduct'){
        $productID = $_POST['productID'];
        $success = $conn->query("UPDATE product SET Status = False WHERE ID = $productID");
    }
    if($req == 'launchproduct'){
        $productID = $_POST['productID'];
        $success = $conn->query("UPDATE product SET Status = True WHERE ID = $productID");
    }
    if($req == 'replenishment'){
        $productID = $_POST['productID'];
        $quantity = $_POST['quantity'];
        $success = $conn->query("UPDATE product SET quantity = $quantity WHERE ID = $productID");
    }
    $conn->close();
    if ($success) {
        echo json_encode(array("success" => true));
    } else {
        echo json_encode(array("success" => false));
    }
}
else if($_SERVER['REQUEST_METHOD'] == "GET"){
    $req = $_GET['request'];
    if($req == 'getSellerProducts'){
        $id = $_GET['id'];
        if(isset($_GET['category'])){
            $category = $_GET['category'];
            $result = $conn->query("select * from product where sellerID = $id and CategoryID = $category");
        }
        else{
            $result = $conn->query("select * from product where sellerID = $id");
        }
        if($result->num_rows > 0){
            $msg = 'success';
            while (($row_result = $result->fetch_assoc()) !== null) {
                $row[] = $row_result;
            }
        }
        else{
            $msg = 'failed'
            $row = null;
        }
        $conn->close();
        echo json_encode(array('msg' => $msg, 'data' => $row));
    }
}
?>