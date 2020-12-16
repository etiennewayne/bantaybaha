
<?php 
session_start();
ob_start();
if($_SESSION['bantay']==false){
  header("Location:login.php");
  }
?>

<?php 
	$ran=mysqli_connect('localhost','root','','bridge');
	if (!$ran){
		
		die("Connection Failed:" .mysqli_connect_error());
	}
	if (isset($_POST['search']))
	{	
			$StartDate=$_POST['StartDate'];
			$EndDate=$_POST['EndDate'];
			$result= mysqli_query($ran,"SELECT * from measures Where date(nDate) Between date('$StartDate') and date('$EndDate') order by nDate");
	}
?> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Bantay Baha-View</title>

	<link rel="stylesheet" type="text/css" href="css/style2.css" />
</head>

<body>


<div id="header">
  <img src="images/Bbicon.png" />
  <div class="navbar">
<a>Bantay Baha: Flood Alarming System using Arduino</a>
</div>
<div class="dropdown">
 <button onclick="myFunction()" class="dropbtn"><?php echo $_SESSION['usr']?></button>
 <div id="myDropdown" class="dropdown-content">   
   <a href="home.php">Home</a>
   <a href="monitoring.php">Monitoring</a>
   <a href="logout.php">Log Out</a>
  </div>
</div>
</div>


<br><br>
<center>
<form method="post">
	SEARCH :
	<input type="date" name="StartDate" style="padding:10px;" <?php if(isset($StartDate)){ echo 'value="'.$StartDate.'"'; } ?>>
	<input type="date" name="EndDate" style="padding:10px;" <?php if(isset($EndDate)){ echo 'value="'.$EndDate.'"'; } ?>>

	<input type="submit" name="search" value="Go" style="padding:10px;">

</form>

<br>
<hr>
<div>
	<h2>Bantay Baha Data</h2><br>	

	<table>
		<tr>
		<tr>
			<th>ID</th>
			<th>Distance (Centimerter)</th>	
			<th>Date/Time</th>
		</tr>
		</tr>

		<?php
		
		
		if(isset($result)){
			while($row = mysqli_fetch_array($result)){

		?>
		
		<tr>
			<td><?php echo $row['id'];?></td>
			<td><?php echo $row['distance'] . 'cm';?></td>
			<td><?php echo $row['nDate'];?></td>
		</tr>
		
			<?php
				} //close while loop
		}
			?>

	</table>
</center>
		
</div>

</body>
</html>
<script>

/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction() {
  document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}

</script>