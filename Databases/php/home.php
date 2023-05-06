<?php
include("database.php");
include("headers.php");

if ($_SERVER['REQUEST_METHOD'] == "POST") {
    $req = $_POST['request'];
    if($req == "getProducts"){
        $category = $_POST['category'];
        if($category == "all"){
            $result = $conn->query("select * FROM product where product.Status = true");
        }
        else{
            $result = $conn->query("select * FROM product where product.Category = '$category' and product.Status = true");
        }
        if ($result->num_rows > 0) {
            $msg = 'success';
            while (($row_result = $result->fetch_assoc()) !== null) {
                $row[] = $row_result;
            }
        }
        $conn->close();
        echo json_encode(array('msg' => $msg, 'data' => $row));
    }
    
}
else if($_SERVER['REQUEST_METHOD'] == "GET"){
    $req = $_GET['request'];
    if ($req == 'getproductcategories'){
        $result = $conn->query("select Name from Category");
        if ($result->num_rows > 0) {
            $msg = 'success';
            while (($row_result = $result->fetch_assoc()) !== null) {
                $row[] = $row_result['Name'];
            }
        }
        $conn->close();
        echo json_encode(array('msg' => 'success', 'categories' => $row));
    }
    if($req == "search"){
        $keyword = $_GET['key'];
        $result = $conn->query("select * from product where Name like '%$keyword%'");
        if ($result->num_rows > 0) {
            $msg = 'success';
            while (($row_result = $result->fetch_assoc()) !== null) {
                $row[] = $row_result;
            }
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