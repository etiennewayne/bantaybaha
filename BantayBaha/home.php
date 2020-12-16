
<?php 
session_start();
ob_start();
if($_SESSION['bantay']==false){
  header("Location:login.php");
  }
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Bantay Baha-Home</title>

	<link rel="stylesheet" type="text/css" href="css/style2.css" />
  
</head>

<body>

<?php 
$ran=mysqli_connect('localhost','root','','bridge')
?>
<div id="header">
  <img src="images/Bbicon.png" />
  <div class="navbar">
<a>Bantay Baha: Flood Alarming System using Arduino</a>
</div>
<div class="dropdown">
 <button onclick="myFunction()" class="dropbtn"><?php echo $_SESSION['usr']?></button>
 <div id="myDropdown" class="dropdown-content">   
 	<a href="monitoring.php">Monitoring</a>
   	<a href="View.php">View</a>
    <a href="logout.php">Log Out</a>
  </div>
</div>
</div>
<div>
	<h1>Bantay Baha Data</h1>	

<center>
	<table>
		<tr>
			<th>ID</th>
			<th>Distance (Centimerter)</th>	
			<th>Date/Time</th>
		</tr>
		<?php 
		$result= mysqli_query($ran,"SELECT * from measures order by id desc");
		while($rs= mysqli_fetch_array($result)){
		?>
		<tr>
			<td><?php echo $rs['id'];?></td>
			<td><?php echo $rs['distance'] . 'cm';?></td>
			<td><?php echo $rs['nDate'];?></td>
		</tr>
		<?php }?>
			
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