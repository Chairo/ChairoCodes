<?PHP
$key = Substr(Base64_Encode(Md5($url, True)), 0, 6);
$key = Str_Replace(Array('+','/','='), Array('-','_',"), $key);
?>