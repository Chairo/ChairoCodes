/**
*Action: Ip2Number
*Input: $ip
*Comment:
*Output:
*CreatDate: 2007-10-30
*Author: Origami
*Update:
*Example:
*/
Function Ip2Number($ip)
{
    $iparray = Explode(".", $ip);
    $int = ($iparray[0] << 24) | ($iparray[1] << 16) | ($iparray[2] << 8) | $iparray[3];
    If ($int < 0) $int+=4294967296;
    Return $int;
}

/**
*Action: Number2Ip
*Input: $int
*Comment:
*Output:
*CreatDate: 2007-10-30
*Author: Origami
*Update:
*Example:
*/
Function Number2Ip($int)
{
    If($int>2147483647){$int = $int-4294967296;}
    $xor = Array(0x000000ff, 0x0000ff00, 0x00ff0000, 0xff000000);
    For($i=0; $i<4; $i++)
    {
        ${"b".$i} = ($int & $xor[$i]) >> ($i*8);
        If (${"b".$i} < 0) ${"b".$i} += 256;
    }
    Return "$b3.$b2.$b1.$b0";
}

