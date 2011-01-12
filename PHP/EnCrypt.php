<?php
/**
*Action: Encrypt/decrypt a string
*Input: $str
*Comment:
*Output:
*CreatDate: 2007-10-30
*Author: Origami
*Update:
*Example: Echo(EnCrypt('Origami'));
*/
Function EnCrypt($str)
{
    $key = 'WXH@3FT*WFW`9T(]Z8+S@B8=#Q2$F2?ES>OGD\22_J8DJ0*X_KNM#-?N7:K`0K.F0SR,NX..]
    <\&3T]OAXS5JVZ5]:0M])#C%.ZN,-3]L.R\'L6.D84C-R142Q`*J*;G@-\4S5I+F&1$)2FC8@-(VT.5FLDA:/
    5F=B4&ZE$?)`WVM<6G/RUIT+?G5I5C>EGJ=_D;G7*ZE<699E8&)*A5H.WV@@D99G&=A?^?;$P(^/ZRK)
    >F)?A3T9*K*-D+LP@GLYX:W$HN93Y0)>;T0M(MZ\'&O4GG%Z:JT`*A6@RD;SCEW0`^;AMFN=N>N_L^
    /E]7M@*,>TK6U2Y/VE,]#^;1@\M&114]S.U5]-R)[9\'OJT1(6J8*6JN6-\;L`(8U]8<9/(^KYM>CA@AB?`^
    3]EB+]^4(HGRWWD+5)3I&A6.A&5EQ<,;-EQP^\FN(RP?8K5;X8QJI[SL>_48\'7K\'HU35\'63)=)F7FA-HWE
    E]H4G7+Z@RS;$<8;*\'R1GY[5+3UDK';
    $result = '';

    $keyChr = Ord(SubStr($key, 1, StrLen($str)));

    For($i = 0; $i < StrLen($str); $i ++)
    {
        $encryptChr = Ord(SubStr($str, $i, 1));
        $xor = $keyChr ^ $encryptChr;
        $result .= Chr($xor);
    }

    Return $result;
}
?>