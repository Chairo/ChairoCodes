<?
Error_Reporting(0);
Header("Content-type: image/png");
$strRealIP = GetIP();    //获得真实IP
$strUserAgent = $_SERVER['HTTP_USER_AGENT'];    //获得UserAgent
$strUserAgent = !Empty($strUserAgent) ? StrToLower($strUserAgent) : 'Other';    //如果取不到UserAgent则为Other
Date_Default_Timezone_Set("Asia/Shanghai");    //设置默认时区为中国/上海
$time = GetDateTimeMk(Time());    //当前时间

$top = "Your Information:";
$line = "----------------------------------";
$info = "Power By: Chairo.Penn";
$WebInfo = "chairo-penn.com";

$wenzi = "IP Address:";
$left = 68;
$width = 175;    //图像宽度
$height =100;    //图像高度
$picture=Imagecreate($width, $height);
$bgcolor=ImageColorAllocate($picture, 225, 250, 225);    //背景颜色，第一个225表示的是红色，250代表绿色，225代表黄色[三色原理]，弄在一起就搭配出一种颜色来，这个可以自己调，范围0-255
$bordercolor=ImageColorAllocate($picture, 0, 0, 0);    //边框颜色，原理同上
$fontcolor=ImageColorAllocate($picture, 0, 0, 0);    //第一种字体颜色
$fontcolor2=ImageColorAllocate($picture, 100, 0, 255);    //第二种字体颜色
$fontcolor3=ImageColorAllocate($picture, 255, 100, 100);    //第三种字体颜色
$origImg = ImageCreateFromPNG("ip.png");    //背景图像，要求必须用png格式。
ImageCopyResized($picture,$origImg,0,0,0,0,$width,$height,ImageSX($origImg),ImageSY($origImg));    //将背景图像和原图片合成代码
//边框设置
Imageline($picture,0,0,$width-1,0,$bordercolor);
Imageline($picture,0,0,0,$height-1,$bordercolor);
Imageline($picture,$width-1,$height-1,$width-1,0,$bordercolor);
Imageline($picture,$width-1,$height-1,0,$height-1,$bordercolor);
//边框设置-EOF-
//文字写入图片
Imagestring($picture, 12, 2, 0, $top, $fontcolor3);
Imagestring($picture, 2, 2, 10, $line, $fontcolor);
Imagestring($picture, 2, 12, 20, $wenzi, $fontcolor);
Imagestring($picture, 2, $left+12, 20, $strRealIP, $fontcolor);
Imagestring($picture, 2, 12, 32, 'OS Version: '.GetOperateSystemVersion($strUserAgent), $fontcolor);
Imagestring($picture, 2, 12, 44, 'Broswer: '.GetBrowserVersion($strUserAgent), $fontcolor);
Imagestring($picture, 2, 12, 54, 'Now: '.$time, $fontcolor);
Imagestring($picture, 2, 2, 62, $line, $fontcolor);
Imagestring($picture, 2, 12, 72, $info, $fontcolor2);
Imagestring($picture, 2, 12, 84, $WebInfo, $fontcolor2);
//文字写入图片-EOF-
Imagepng($picture);    //合成图像
ImageDestroy($picture);    //破坏图像流，释放内存

/**
*Action: Get Operate System Version
*Input: $strUserAgent string
*Comment:
*Output: $strOperateSystemVersion string
*CreatDate: 2009-03-26
*Author: Chairo
*Update:
*/
Function GetOperateSystemVersion($strUserAgent)
{
    $strOperateSystemVersion = 'Other';

    If(StrPos($strUserAgent, 'win'))    //如果是Windows操作系统
    {
        //Windows NT
        If(StrPos($strUserAgent, 'nt'))
        {
            $strOperateSystemVersion = 'Windows NT';
        }

        //Windows XP
        If(StrPos($strUserAgent, 'nt 5.1'))
        {
            $strOperateSystemVersion = 'Windows XP';
        }

        //Windows 2003
        If(StrPos($strUserAgent, 'nt 5.2'))
        {
            $strOperateSystemVersion = 'Windows 2003';
        }

        //Windows 2000
        If(StrPos($strUserAgent, 'nt 5.0'))
        {
            $strOperateSystemVersion = 'Windows 2000';
        }

        //Windows Vista
        If(StrPos($strUserAgent, 'nt 6.0'))
        {
            $strOperateSystemVersion = 'Windows Vista';
        }

        //Windows Seven
        If(StrPos($strUserAgent, 'nt 6.1'))
        {
            $strOperateSystemVersion = 'Windows 7';
        }

        //Windows ME
        If(StrPos($strUserAgent, 'win 9x') && StrPos($strUserAgent, 'win 4.90'))
        {
            $strOperateSystemVersion = 'Windows ME';
        }

        //Windows 98
        If(StrPos($strUserAgent, '98'))
        {
            $strOperateSystemVersion = 'Windows 98';
        }

        //Windows 95
        If(StrPos($strUserAgent, '95'))
        {
            $strOperateSystemVersion = 'Windows 95';
        }

        //Windows 32
        If(StrPos($strUserAgent, '32'))
        {
            $strOperateSystemVersion = 'Windows 32';
        }

        //Windows CE
        If(StrPos($strUserAgent, 'ce'))
        {
            $strOperateSystemVersion = 'Windows CE';
        }
    }
    Else    //非Windows操作系统
    {
        //Unix
        If(StrPos($strUserAgent, 'unix'))
        {
            $strOperateSystemVersion = 'Unix';
        }

        //Linux
        If(StrPos($strUserAgent, 'linux'))
        {
            $strOperateSystemVersion = 'Linux';
        }

        //SunOS
        If(StrPos($strUserAgent, 'sun') && StrPos($strUserAgent, 'os'))
        {
            $strOperateSystemVersion = 'SunOS';
        }

        //IBM OS/2
        If(StrPos($strUserAgent, 'ibm') && StrPos($strUserAgent, 'os'))
        {
            $strOperateSystemVersion = 'IBM OS/2';
        }

        //Macintosh
        If(StrPos($strUserAgent, 'mac') && StrPos($strUserAgent, 'pc'))
        {
            $strOperateSystemVersion = 'Macintosh';
        }

        //PowerPC
        If(StrPos($strUserAgent, 'powerpc'))
        {
            $strOperateSystemVersion = 'PowerPC';
        }

        //AIX
        If(StrPos($strUserAgent, 'aix'))
        {
            $strOperateSystemVersion = 'AIX';
        }

         //HPUX
        If(StrPos($strUserAgent, 'hpux'))
        {
            $strOperateSystemVersion = 'HPUX';
        }

        //BSD
        If(StrPos($strUserAgent, 'bsd'))
        {
            $strOperateSystemVersion = 'BSD';
        }

        //NetBSD
        If(StrPos($strUserAgent, 'netbsd'))
        {
            $strOperateSystemVersion = 'NetBSD';
        }

        //OSF1
        If(StrPos($strUserAgent, 'osf1'))
        {
            $strOperateSystemVersion = 'OSF1';
        }

        //IRIX
        If(StrPos($strUserAgent, 'irix'))
        {
            $strOperateSystemVersion = 'IRIX';
        }

        //FreeBSD
        If(StrPos($strUserAgent, 'freebsd'))
        {
            $strOperateSystemVersion = 'FreeBSD';
        }

        //OSF1
        If(StrPos($strUserAgent, 'osf1'))
        {
            $strOperateSystemVersion = 'OSF1';
        }

        //Teleport
        If(StrPos($strUserAgent, 'teleport'))
        {
            $strOperateSystemVersion = 'Teleport';
        }

        //Flashget
        If(StrPos($strUserAgent, 'flashget'))
        {
            $strOperateSystemVersion = 'Flashget';
        }

        //Webzip
        If(StrPos($strUserAgent, 'webzip'))
        {
            $strOperateSystemVersion = 'Webzip';
        }

        //OffLine
        If(StrPos($strUserAgent, 'offline'))
        {
            $strOperateSystemVersion = 'OffLine';
        }
   }
    Return $strOperateSystemVersion;
}

/**
*Action: Get Browser Version
*Input: $strUserAgent string
*Comment:
*Output: $strBrowserVersion string
*CreatDate: 2009-03-26
*Author: Chairo
*Update:
*/
Function GetBrowserVersion($strUserAgent)
{
    $strBrowserVersion = 'Other';

    //Microsoft IE 5.5
    If(StrPos($strUserAgent, 'msie 5.5'))
    {
        $strOperateSystemVersion = 'Microsoft IE 5.5';
    }

    //Microsoft IE 6.0
    If(StrPos($strUserAgent, 'msie 6.0'))
    {
        $strOperateSystemVersion = 'Microsoft IE 6.0';
    }

    //Microsoft IE 7.0
    If(StrPos($strUserAgent, 'msie 7.0'))
    {
        $strOperateSystemVersion = 'Microsoft IE 7.0';
    }

    //Microsoft IE 8.0
    If(StrPos($strUserAgent, 'msie 8.0'))
    {
        $strOperateSystemVersion = 'Microsoft IE 8.0';
    }

    //Netscape
    If(StrPos($strUserAgent, 'netscape'))
    {
        $strOperateSystemVersion = 'Netscape';
    }

    //Opera
    If(StrPos($strUserAgent, 'opera'))
    {
        $strOperateSystemVersion = 'Opera';
    }

    //Firefox
    If(StrPos($strUserAgent, 'firefox'))
    {
        $strOperateSystemVersion = 'Firefox';
    }

    //Safari
    If(StrPos($strUserAgent, 'safari'))
    {
        $strOperateSystemVersion = 'Safari';
    }

    //Chrome
    If(StrPos($strUserAgent, 'chrome'))
    {
        $strOperateSystemVersion = 'Chrome';
    }
    Return $strOperateSystemVersion;
}

/**
*Action: Get browser's IP address
*Input:
*Comment:
*Output: $RemoteIP string
*CreatDate: 2009-03-26
*Author: Chairo
*Update:
*/
Function GetIP()
{
    If (!Empty($_SERVER['HTTP_CLIENT_IP']))
        $strRemoteIP = $_SERVER['HTTP_CLIENT_IP'];
    Else If (!Empty($_SERVER['HTTP_X_FORWARDED_FOR']))
        $strRemoteIP = $_SERVER['HTTP_X_FORWARDED_FOR'];
    Else If (!Empty($_SERVER['REMOTE_ADDR']))
        $strRemoteIP = $_SERVER['REMOTE_ADDR'];
    If(IsIP($strRemoteIP))
    {
        Return $strRemoteIP;
    }
    Else
    {
        Return 'Can\'t get!';
    }
}

/**
*Action: Check str is a ip or not
*Input: $strIP string
*Comment:
*Output: bool
*CreatDate: 2009-03-26
*Author: Chairo
*Update:
*/
Function IsIP($strIP)
{
    If (Preg_Match('/^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$/', $strIP))
    {
        Return true;
    }
    Else
    {
        Return false;
    }
}

Function GetDateTimeMk($mktime)
{
    If ($mktime == '' || Ereg('[^0-9]', $mktime)) Return '';
    Return StrFTime('%Y-%m-%d %H:%M:%S', $mktime);
}

?>
