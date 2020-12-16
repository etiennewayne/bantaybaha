<?php


if($_SERVER['REQUEST_METHOD']=='GET'){


    $status=$_REQUEST["distance"];

    if($status < 1){
        $status = 0;
    }
 
   $conn = mysqli_connect("localhost","root","","bridge");

    // Check connection
    if (mysqli_connect_errno())
    {
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
    }
    
    $sql1 = "INSERT INTO measures (distance) VALUES ('$status')";

    if (mysqli_query($conn, $sql1)) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . mysqli_error($conn);
    }

    
    // $sql = "SELECT * FROM data";
    // $result = mysqli_query($conn, $sql);

    // if (mysqli_num_rows($result) >= 0) {
    
       
    // }
            
		  

  // mysql_close($Connection);
    mysqli_close($conn);



}
    

?>