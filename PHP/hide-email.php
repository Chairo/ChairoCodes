<html>
<title>Hidden your email address</title>
<style>
body {font-size:12px;}
</style>
<body>
<?php
function Email2ASCII($character) {
	$h = StrLen($character);
	for ($i=0; $i<$h; $i++) {
		$c .= "&#".ord($character[$i]).";";
	}
	return $c;
}
?>
<?PHP
If(IsSet($_POST["submit"])){
	$emailaddress = Email2ASCII($_POST["email"]);
	$cemail = HtmlSpecialChars($emailaddress);
	Echo "Your email address is:<br />".$emailaddress."<br />";
?>
<input type="text" value="<?=$cemail?>" name="cc" size="30"> &nbsp;<input type="button" value="Copy it to your clipboard" onclick='window.clipboardData.setData("Text",cc.value);alert("Copy the email succeed");'>
<form action="" method="post" >
<input type="hidden" value="" name="email"><font color="red">Now you can put it in any websitepages<br>
<input type="submit" value="Input again">
<?PHP
}Else{
?>
Input your email address£º
<form action="" method="post">
<input type="text" value="" name="email">  
<input name="submit" type="submit" id="submit" value="Change it">
</form>
<?PHP
}?>
</body>
</html>