<?php
session_start();

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Bantay Baha</title>

<link rel="stylesheet" type="text/css" href="css/style.css">

</head>

<body>


<form id="form1" name="form1" method="post" action="">
<div id="header2">
  	<img src="images/Bbicon.png" />
  	<div class="navbar">
		<a>BantayBaha</a>
		
		<div id="p">

			<div class="login-form">
				Username : <input name="a" type="text" class="textstyle" /> Password : <input name="b" type="password" class="textstyle" />
				<input type="submit" name="btn_login" class="btn" value="Log In" />
			</div>


		</div>
	</div>
</div>

<div class="propaganda">
	<img src="images/Bbbg.png">
</div>
</form>


</body>
</html>
<?php 


if (isset ($_POST['btn_login'])=="Log In"){

	$user=$_POST['a'];
	$pass=$_POST['b'];
	
$dbhost = 'localhost';
$dbuser = 'root';
$dbpass = '';
$dbname = 'bridge';

//Create database connection
  $dblink = new mysqli($dbhost, $dbuser, $dbpass, $dbname);

//Check connection was successful
  if ($dblink->connect_errno) {
     printf("Failed to connect to database");
     exit();
  }

	$stmt = $dblink->prepare($query = "SELECT * FROM users WHERE username=? and pwd = ?");
	$stmt->bind_param('ss', $user, $pass);
	$stmt->execute();
	$result = $stmt->get_result();
	$stmt->close();
	
	$numrow = $result->num_rows;
	
	
	
	
	
	
	if ($numrow > 0){
		$_SESSION['bantay']=true;
		$_SESSION['usr']=$user;
		header('Location:home.php');
	}else if ($user=="" && $pass==""){
		echo '<script language="javascript">
		alert("Incorrect username or password");
		</script>';
	}else{
		echo '<script language="javascript">
				alert("Incorrect username or password");
			</script>';
	}
}



// Initialize variable for database credentials


?>