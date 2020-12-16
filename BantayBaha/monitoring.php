
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
	<title>Bantay Baha-View</title>

	<link rel="stylesheet" type="text/css" href="css/style2.css" />

        <script src="js/jquery.min.js"></script>
        <script src="js/chart.js"></script>
        <script src="js/moment.js"></script>
        



        <script>
		
	var ajaxData;
		
		
            $(document).ready(function(){
				
				loadDoc();
              var count = 10;
              var data = {
                  labels : ["0:00:00","0:00:00","0:00:00","0:00:00","0:00:00", "0:00:00", "0:00:00", "0:00:00", "0:00:00", "0:00:00"],
                    datasets : [
                      {
                            //fillColor : "rgba(220,220,220,0.5)",
                            //strokeColor : "rgba(220,220,220,1)",
                            fillColor : "rgba(151,187,205,0.5)",
                            strokeColor : "rgba(151,187,205,1)",
                            //pointColor : "rgba(220,220,220,1)",
                            pointColor : "rgba(151,187,205,1)",
                            pointStrokeColor : "#fff",
                            data : [0,0,0,0,0,0,0,0,0,0]
                        },
                        /* {
                            fillColor : "rgba(151,187,205,0.5)",
                            strokeColor : "rgba(151,187,205,1)",
                            pointColor : "rgba(151,187,205,1)",
                            pointStrokeColor : "#fff",
                            data : [28,48,40,19,96,87,66,97,92,85]
                        } */
                    ]
              }
              // this is ugly, don't judge me
				var updateData = function(oldData){
					
					loadDoc();
					
					var labels = oldData["labels"];
					var dataSetA = oldData["datasets"][0]["data"];
					//var dataSetB = oldData["datasets"][1]["data"];
					
					var obj = JSON.parse(ajaxData);
					
					var ntime = moment(new Date(obj.nDate).getTime()).format('hh:mm:ss A');
					//var sqlTime = moment(new Date().getTime()).format('YYYY-MM-DD HH:mm:ss');
					
					labels.push(ntime);
					labels.shift();
				  //  count++;
				
					var dtime = obj.nDate;
					//var ntime = moment(dtime.getTime()).format('hh:mm:ss A');
					
					
					
					var lastlabel = labels[8];
					
					//moment(ntime.getTime() + 1).format('HH:mm:ss');
					
					console.log('AJAX Data :' + obj.distance);
					//var newDataA = dataSetA[9] + (Math.floor(Math.random() * (100)));
					//var newDataA = Math.floor(Math.random() * (100));
					var newDataA = obj.distance;
					//var newDataB = dataSetB[9] + (20 - Math.floor(Math.random() * (41)));
					dataSetA.push(newDataA);
			  
					console.log('AJAX : ' + ajaxData);
					
					//dataSetB.push(newDataB);
					dataSetA.shift();
					//dataSetB.shift();    
                };
                  
              var optionsAnimation = {
                //Boolean - If we want to override with a hard coded scale
                scaleOverride : true,
                //** Required if scaleOverride is true **
                //Number - The number of steps in a hard coded scale
                scaleSteps : 10,
                //Number - The value jump in the hard coded scale
                scaleStepWidth : 10,
                //Number - The scale starting value
                scaleStartValue : 0
              }
              
              // Not sure why the scaleOverride isn't working...
              var optionsNoAnimation = {
                animation : false,
                //Boolean - If we want to override with a hard coded scale
                scaleOverride : true,
                //** Required if scaleOverride is true **
                //Number - The number of steps in a hard coded scale
                scaleSteps : 10,
                //Number - The value jump in the hard coded scale
                scaleStepWidth : 10,
                //Number - The scale starting value
                scaleStartValue : 0
              }
              
              //Get the context of the canvas element we want to select
              var ctx = document.getElementById("myChart").getContext("2d");
              //var optionsNoAnimation = {animation : false}
              var myNewChart = new Chart(ctx);
              myNewChart.Line(data, optionsAnimation);  
              
              setInterval(function(){
                updateData(data);
                myNewChart.Line(data, optionsNoAnimation)
                ;}, 2000
              );
			
            });
			
			function loadDoc() {
			  var xhttp = new XMLHttpRequest();
			  xhttp.onreadystatechange = function() {
				if (this.readyState == 4 && this.status == 200) {
					//var myObj = JSON.parse(this.responseText);
					//document.getElementById("demo").innerHTML = this.responseText;
					ajaxData = this.responseText;
					//ajaxDistance = myObj.distance;
				// alert(this.responseText);
				}
			  };
			  xhttp.open("GET", "livedata.php", true);
			  xhttp.send();
			} 
			
			
			
 
        </script>

		

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
   			<a href="home.php">Monitoring</a>
   			<a href="logout.php">Log Out</a>
  		</div>
	</div>
</div>



        <h1>Live Updating Chart</h1>
        
        <canvas id="myChart" width="1200" height="300"></canvas>


<br>
<br>

<div id="demo">
  <h2><b>TODAY IS :<b></h2>
  <?php 
 echo date("l"). "<br>";
echo date("m-d-y") ;
	?>
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