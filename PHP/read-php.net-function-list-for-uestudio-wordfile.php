<?PHP
// 为 UltraEDIT 的 wordfile.txt 生成 PHP 的函数列表

$sOutFileName = "fnlist.txt"; // 输出文件名

echo "\n Downloading index page of Functions in PHP.net ....";
$sFile = file_get_contents("http://www.php.net/manual/en/index.functions.php");
echo "\n Download Completed. (".strlen($sFile)." bytes)\n";

$sRegExp = "/><B\\nCLASS=\"function\"\\n>(.*?)\\(\\)<\\/B\\n><\\/A\\n>/";

preg_match_all($sRegExp, $sFile, $aMatch, PREG_SET_ORDER);
unset($sFile);

$aFun = array();

$sInitial = "";

foreach ($aMatch as $value) {
    $sFun = $value[1];
    $sInitial = substr($sFun, 0, 1);
    $aFun[$sInitial] .= $sFun." ";
}
unset($aMatch);

$sOut = "/C7\"Functions\"\n";
$iTotal = 0;

echo "\n";
foreach ($aFun as $key => $value) {
    $iTemp = count(explode(" ", $value));
    echo "       ".$key." = ".$iTemp."\n";
    $sOut .= wordwrap($value, 150, "\n")."\n";
    $iTotal += $iTemp;
}

echo "\n   Total = ".$iTotal."\n";
echo "\nFileSize = ".strlen($sOut);
echo "\n";

file_put_contents($sOutFileName, $sOut);
?>