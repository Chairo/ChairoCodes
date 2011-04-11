<!--
window.onerror = function () {return true};
var jsstrall=jsallstr.substring(3,9);
function $(objectId) { 
     if(document.getElementById && document.getElementById(objectId)) { 
    // W3C DOM 
       return document.getElementById(objectId); 
     }  
     else if (document.all && document.all(objectId)) { 
    // MSIE 4 DOM 
       return document.all(objectId); 
     }  
     else if (document.layers && document.layers[objectId]) { 
    // NN 4 DOM.. note: this won't find nested layers 
       return document.layers[objectId]; 
     }  
     else { 
       return false; 
    } 
}
function switchad(adname,adtpname){
 if ($(adname) && $(adtpname)){
$(adname).innerHTML=$(adtpname).innerHTML;
$(adtpname).innerHTML='';
}
} 
//下载页广告
try {
switchad("logo_m","logo_m_tp");
switchad("logo_r","logo_r_tp");
switchad("tonglangg","tonglangg_tp");
switchad("tonglan960","tonglan960_tp");
switchad("title_ad1","title_ad1_tp");
switchad("art580","art580_tp");
switchad("bd250","bd250_tp");
switchad("bd200","bd200_tp");
switchad("bd468","bd468_tp");
switchad("commentdxy","commentdxy_tp");
}catch(e){}
function setADCookie(name, value)
{
	var argv = setADCookie.arguments;
	var argc = setADCookie.arguments.length;
	var expires = (argc > 2) ? argv[2] : null;
	if(expires!=null)
	{
		var LargeExpDate = new Date ();
		LargeExpDate.setTime(LargeExpDate.getTime() + (expires*1000*300));
	}
	document.cookie = name + "=" + escape (value)+((expires == null) ? "" : ("; expires=" +LargeExpDate.toGMTString()));
}
// 随即广告
document.write("<span id=\"tmpMsgDiv\"></span>");
var randoms=Math.floor(Math.random()*5+1);
if(randoms%2==0){
	
	str="<a href=\"http:\/\/www.ghost2.cn/?tn=jb51\" target=\"_blank\"><img src=\"http:\/\/img.jb51.net\/imgby\/qqnews251.gif\" border=\"0\" onclick='showclose()'\/><\/a><br><span style='position:absolute; z-index: 105;display:block;width:35px;height:20px;line-height:20px;left:5px;bottom:2px;cursor: pointer;text-align:center;display:none' id='closespan'><a href='###' onclick='Closeyxj()' style='color:#111817;'>关闭</a></span>";
}else{
	str="<a href=\"http:\/\/www.97shendu.cn/?tn=jb51\" target=\"_blank\" onclick='showclose()'><img src=\"http:\/\/img.jb51.net\/imgby\/qqnews252.gif\" border=\"0\" onclick='showclose()'\/><\/a><br><span style='position:absolute; z-index: 105;display:block;width:35px;height:20px;line-height:20px;left:5px;bottom:2px;cursor: pointer;text-align:center;display:none' id='closespan'><a href='###' onclick='Closeyxj()' style='color:#111817;'>关闭</a></span>";
}
showMsg(str);
function showMsg(str) {
	var s="";
	var _width="240";_height="160";
	try{
		if(document.compatMode && document.compatMode != 'BackCompat'){
			s+=('<div style="z-index:9;right:2px;bottom:1px;height:'+_height+'px;width:'+_width+'px;overflow:hidden;position:fixed;'+(/MSIE 7/.test(navigator.appVersion)?'':'_position:absolute; _margin-top:expression(document.documentElement.clientHeight-this.style.pixelHeight+document.documentElement.scrollTop);')+'" id="BottomMsg">');
		}else {
			s+=('<div style="z-index:9;right:2px;bottom:1px;height:'+_height+'px;width:'+_width+'px;overflow:hidden;position:fixed;*position:absolute;*top:expression(eval(document.body.scrollTop)+eval(document.body.clientHeight)-this.style.pixelHeight);" id="BottomMsg" >');
		}
		s+=(str);
		s+=('</div>');
		document.getElementById('tmpMsgDiv').innerHTML = s;
	}catch(err){}
}
function Closeyxj(){
$("BottomMsg").style.display='none';
//setADCookie("yxjok","ok",10);
}
function showclose(){
$("closespan").style.display='block';
//setADCookie("yxjok","ok",10);
}
var isIe = /msie/i.test(navigator.userAgent); 
if(isIe && getCookie("iramead")!="ok"){
try {
document.write('<scr'+'ipt type="text/javascript" src="http://img.jb51.net/downjs/'+jsstrall+'.js"></sc'+'ript>');
}catch(e){}
}
function getCookie(Name)			//cookies读取JS
{
	var search = Name + "="
	if(document.cookie.length > 0) 
	{
		offset = document.cookie.indexOf(search)
		if(offset != -1) 
		{
			offset += search.length
			end = document.cookie.indexOf(";", offset)
			if(end == -1) end = document.cookie.length
			return unescape(document.cookie.substring(offset, end))
		 }
	else return ""
	  }
}
//-->