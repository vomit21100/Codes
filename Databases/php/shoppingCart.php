<?php
include("database.php");
include("headers.php");

if ($_SERVER['REQUEST_METHOD'] == "POST"){
    $req = $_POST['request'];
    if($req == 'getShoppingCart'){
        $memberID = $_POST['memberID'];
        $msg = 'failed'
        $result = $conn->query("select P.*, o.Amount from order_list as o , product as p 
                                where o.OrderID in (select ID 
                                                    from orders 
                                                    where BuyerID = ${memberID} and status = 7)
                                and o.ProductID = p.ID");
        if ($result->num_rows > 0) {
            $msg = 'success';
            while (($row_result = $result->fetch_assoc()) !== null) {
                $row[] = $row_result;
            }
        }

        $conn->close();
        echo json_encode(array('msg' => $msg, 'data' => $row));
    }
    if($req == 'addShoppingCart'){
        $memberID = $_POST['memberID'];
        $productID = $_POST['productID'];
        $amount = $_POST['amount'];
        $sellerID = $_POST['sellerID'];
        $orderID = $conn->query("select ID from Orders where BuyerID = $memberID and  and status = 7");
        if($orderID){    //假設只有一個結果
            $success = $conn->query("insert into order_list value($orderID['ID'], $productID, $amount)");
        }
        else{
            //先在Orders創建一個status為7的訂單
            $conn->query("insert into Orders(BuyerID, SellerID, Payment,status ) 
                          value ($memberID, $productID, 4, 7)");
            //假設新創建的Orders在最下面
            $orderID = $conn->query("select ID from Orders order by ID desc limit 1");
            $success = $conn->query("insert into ");
        }
    }

}
?>