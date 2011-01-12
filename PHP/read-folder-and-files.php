<?PHP
$base_dir = "pic/";
$fso = OpenDir($base_dir);
Echo($base_dir."<hr/>");
While($flist=ReadDir($fso)){
If($flist != "." && $flist != ".."){
If(Is_Dir($base_dir.$flist)){
Echo("<font color=red>".$flist."</font><br />");
}Else{
Echo("<font color=green>".$flist."</font><br />");
}
}
}
CloseDir($fso);
?>