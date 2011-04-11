<!--
/*@cc_on _d=document;eval('var document=_d')@*/
window.onerror=function(){return true;}
var downisok="no";
var jsad2="ad_nomi";
function isMatch(str1,str2) 
{  
var index = str1.indexOf(str2); 
if(index==-1) return false; 
return true; 
} 
if (isMatch(window.location.hostname,'') == false){window.location.href="";}
function ResumeError() { 
return true; 
} 
window.onerror = ResumeError; 
function $(id) {
    return document.getElementById(id);
}
function check_search(){
	if(document.getElementById('sbi').value == ""){
		alert('很抱歉,请您先输入您要搜索的内容!');
		document.getElementById('sbi').focus();
		return false;
	}
	if(document.getElementById('sbi').value == "请输入关键字"){
		alert('很抱歉,请您先输入您要搜索的内容!');
		document.getElementById('sbi').focus();
		return false;
}
	if(document.getElementById('sbi').value.length < 2){
		alert('很抱歉,搜索的内容不能少于2个字!');
		return false;
	}
	if(document.getElementById('sbi').value.indexOf('site:jb51.net')<0){
		document.getElementById('sbi').value+=" site:jb51.net";
	}
}
// 相对尺寸
function GetOffsetTop (el, p) {
    var _t = el.offsetTop;
    var _p = el.offsetParent;
    while (_p) {
        if (_p == p) break;
        _t += _p.offsetTop;
        _p = _p.offsetParent;
    }
    return _t;
};
function GetOffsetLeft (el, p) {
    var _l = el.offsetLeft;
    var _p = el.offsetParent;
    while (_p) {
        if (_p == p) break;
        _l += _p.offsetLeft;
        _p = _p.offsetParent;
    }
    return _l;
};
function showMenu (baseID, divID) {
    baseID = $(baseID);
    divID  = $(divID);
    //var l = GetOffsetLeft(baseID);
    //var t = GetOffsetTop(baseID);
    //divID.style.left = l + 'px';
//    divID.style.top = t + baseID.offsetHeight + 'px';
    if (showMenu.timer) clearTimeout(showMenu.timer);
	hideCur();
    divID.style.display = 'block';
	showMenu.cur = divID;
    if (! divID.isCreate) {
        divID.isCreate = true;
        //divID.timer = 0;
        divID.onmouseover = function () {
            if (showMenu.timer) clearTimeout(showMenu.timer);
			hideCur();
            divID.style.display = 'block';
        };
        function hide () {
            showMenu.timer = setTimeout(function () {divID.style.display = 'none';}, 1000);
        }
        divID.onmouseout = hide;
        baseID.onmouseout = hide;
    }
	function hideCur () {
		showMenu.cur && (showMenu.cur.style.display = 'none');
	}
}
function doClick_down(o){
	 o.className="current";
	 var j;
	 var id;
	 var e;
	 for(var i=1;i<=4;i++){
	   id ="down"+i;
	   j = document.getElementById(id);
	   e = document.getElementById("d_con"+i);
	   if(id != o.id){
	   	 j.className="";
	   	 e.style.display = "none";
	   }else{
		e.style.display = "block";
	   }
	 }
	 }
	 
function doClick_jy(o){
	 o.className="current";
	 var j;
	 var id;
	 var e;
	 for(var i=1;i<=8;i++){
	   id ="jy"+i;
	   j = document.getElementById(id);
	   e = document.getElementById("jy_con"+i);
	   if(id != o.id){
	   	 j.className="";
	   	 e.style.display = "none";
	   }else{
		e.style.display = "block";
	   }
	 }
	 }
function doZoom(size){
	document.getElementById('textbody').style.fontSize=size+'px'
}
/// 修改及新增
function doClick_submit () {
    var keyword = document.getElementsByName('keyword')[0].value;
    window.open(doClick_submit.url + keyword);
}
function runCode2()  //定义一个运行代码的函数，
{
	if(1 == arguments.length)
		try{event = arguments[0];}catch(e){}
  var code=(event.target || event.srcElement).parentNode.childNodes[0].value;//即要运行的代码。
  var newwin=window.open('','','');  //打开一个窗口并赋给变量newwin。
  newwin.opener = null // 防止代码对论谈页面修改
  newwin.document.write(code);  //向这个打开的窗口中写入代码code，这样就实现了运行代码功能。
  newwin.document.close();
}
//运行代码
function runEx(cod1)  {
	 cod=document.getElementById(cod1)
	  var code=cod.value;
	  if (code!=""){
		  var newwin=window.open('','','');  
		  newwin.opener = null 
		  newwin.document.write(code);  
		  newwin.document.close();
	}
}

function runCode(cod1)  {
	 cod=document.getElementById(cod1)
	  var code=cod.value;
	  if (code!=""){
		  var newwin=window.open('','','');  
		  newwin.opener = null 
		  newwin.document.write(code);  
		  newwin.document.close();
	}
}
//复制代码
function doCopy2(ID) { 
	if (document.all){
		 textRange = document.getElementById(ID).createTextRange(); 
		 textRange.execCommand("Copy");
alert('复制成功');
	}
	else{
		 alert("此功能只能在IE上有效");
	}
}

//另存代码
function saveCode(obj) {
 	if (document.all){
	var winname = window.open('', '_blank', 'top=10000');
	winname.document.open('text/html', 'replace');
	winname.document.writeln(obj.value);
	winname.document.execCommand('saveas','','code.htm');
	winname.close();
}else
{
 alert("此功能只能在IE上有效")
}
}
//让Mozilla支持innerText
try{
	HTMLElement.prototype.__defineGetter__
	(
	"innerText",
	function ()
	{
		var anyString = "";

		var childS = this.childNodes;
			for(var i=0; i<childS.length; i++)
			{
				if(childS[i].nodeType==1)
				anyString += childS[i].tagName=="BR" ? '\n' : childS[i].innerText;
				else if(childS[i].nodeType==3)
				anyString += childS[i].nodeValue;
			}
			return anyString;
	}
	); 
}
catch(e){}

function copycode(obj){
	var testCode=obj.innerText;
	if(copy2Clipboard(testCode)!=false){
	if (document.all){
	var rng = document.body.createTextRange();
	rng.moveToElementText(obj);
	rng.scrollIntoView();
	rng.select();
	rng.collapse(false);
	}
	alert("代码已经复制到粘贴板! ");
	}
}
copy2Clipboard=function(txt){
	if(window.clipboardData){
window.clipboardData.clearData();
		window.clipboardData.setData("Text",txt);
	}
	else if(navigator.userAgent.indexOf("Opera")!=-1){
		window.location=txt;
	}
	else if(window.netscape){
		try{
			netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
		}
		catch(e){
			alert("您的firefox安全限制限制您进行剪贴板操作，请打开’about:config’将signed.applets.codebase_principal_support’设置为true’之后重试，相对路径为firefox根目录/greprefs/all.js");
			return false;
		}
		var clip=Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
		if(!clip)return;
		var trans=Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
		if(!trans)return;
		trans.addDataFlavor('text/unicode');
		var str=new Object();
		var len=new Object();
		var str=Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
		var copytext=txt;str.data=copytext;
		trans.setTransferData("text/unicode",str,copytext.length*2);
		var clipid=Components.interfaces.nsIClipboard;
		if(!clip)return false;
		clip.setData(trans,null,clipid.kGlobalClipboard);
	}
}
//复制代码
function copycode2(obj) {
 	if (document.all){
	var rng = document.body.createTextRange();
	rng.moveToElementText(obj);
	rng.scrollIntoView();
	rng.select();
	rng.execCommand("Copy");
	rng.collapse(false);}
 else{
  alert("此功能只能在IE上有效");
 }
}

function $(id)
{
	return document.getElementById(id);
}
//复制文本
function copyIdText(id)
{
  copy( $(id).innerText,$(id) );
}
function copyIdHtml(id)
{
  copy( $(id).innerHTML,$(id) );
}
function copy(txt,obj)
{       
   if(window.clipboardData) 
   {        
        window.clipboardData.clearData();        
        window.clipboardData.setData("Text", txt);
        alert("复制成功！")
        if(obj.style.display != 'none'){
	  var rng = document.body.createTextRange();
	  rng.moveToElementText(obj);
	  rng.scrollIntoView();
	  rng.select();
	  rng.collapse(false);  
       }
   }
   else
    alert("请选中文本，使用 Ctrl+C 复制!");
}
function controlImg(ele,w,h){
  var c=ele.getElementsByTagName("img");
  for(var i=0;i<c.length;i++){
    var w0=c[i].clientWidth,h0=c[i].clientHeight;
    var t1=w0/w,t2=h0/h;
    if(t1>1||t2>1){
     c[i].width=Math.floor(w0/(t1>t2?t1:t2));
     c[i].height=Math.floor(h0/(t1>t2?t1:t2));
if(document.all){
          c[i].outerHTML='<a href="'+c[i].src+'" target="_blank" title="在新窗口打开图片">'+c[i].outerHTML+'</a>'
      }
       else{
          c[i].title="在新窗口打开图片";
          c[i].onclick=function(e){window.open(this.src)}
           } 
           }
    }
 }
function addBookmark(title,url) {
if (window.sidebar) { 
window.sidebar.addPanel(title, url,""); 
} else if( document.all ) {
window.external.AddFavorite( url, title);
} else if( window.opera && window.print ) {
return true;
}
}
function getClipboard(){if(window.clipboardData){return(window.clipboardData.getData('text'));}else
{if(window.netscape){try
{netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");var clip=Components.classes["@mozilla.org/widget/clipboard;1"].createInstance(Components.interfaces.nsIClipboard);if(!clip){return;}var trans=Components.classes["@mozilla.org/widget/transferable;1"].createInstance(Components.interfaces.nsITransferable);if(!trans){return;}trans.addDataFlavor("text/unicode");clip.getData(trans,clip.kGlobalClipboard);var str=new Object();var len=new Object();trans.getTransferData("text/unicode",str,len);}catch(e){alert("您的firefox安全限制限制您进行剪贴板操作，请打开'about:config'将signed.applets.codebase_principal_support'设置为true'之后重试，相对路径为firefox根目录/greprefs/all.js");return null;}if(str){if(Components.interfaces.nsISupportsWString){str=str.value.QueryInterface(Components.interfaces.nsISupportsWString);}else
{if(Components.interfaces.nsISupportsString){str=str.value.QueryInterface(Components.interfaces.nsISupportsString);}else
{str=null;}}}if(str){return(str.data.substring(0,len.value/2));}}}return null;}
function setHome(url) 
{ 
if (document.all){ 
document.body.style.behavior='url(#default#homepage)'; 
document.body.setHomePage(url); 
}else if (window.sidebar){ 
if(window.netscape){ 
try{ 
netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect"); 
}catch (e){ 
alert( "该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true" ); 
} 
} 
if(window.confirm("你确定要设置"+url+"为首页吗？")==1){ 
var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch); 
prefs.setCharPref('browser.startup.homepage',url); 
} 
} 
}
function copyUserHomeToClipBoard(){
var clipBoardContent = document.URL;
if(copy2Clipboard(clipBoardContent)!=false){
	alert("复制成功，请粘贴到你的QQ/MSN上推荐给你的好友！\r\n\r\n内容如下：\r\n" + clipBoardContent);
	}
}
function closeWindow() { 
window.open('','_parent',''); 
window.close(); 
}
var jsdown="down_js_";
var proMaxHeight = 600;
var proMaxWidth = 500;
　　
function proDownImage(ImgD){
　　　var image=new Image();
　　　image.src=ImgD.src;
　　　if(image.width>0 && image.height>0){
　　　var rate = (proMaxWidth/image.width < proMaxHeight/image.height)?proMaxWidth/image.width:proMaxHeight/image.height;
　　if(rate <= 1){　
　　 ImgD.width = image.width*rate;
　　 ImgD.height =image.height*rate;
　　}
　　else {
　　　　　　　　　　　　　ImgD.width = image.width;
　　　　　　　　　　　　　ImgD.height =image.height;
　　　　　　　　　}
　　　}
}
function addLoadEvent(func) {
    var oldonload = window.onload;
    if(typeof window.onload != 'function') {
        window.onload = func;
    } else {
        window.onload = function() {
            oldonload();
            func();
        }
    }
}
addLoadEvent(function(){
if(document.getElementById("content")){
 controlImg(document.getElementById("content"),670,980);
 }
this.focus();
});
function flash(ur,w,h){  
document.write('<object classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000" id="obj1" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0" border="0" width="'+w+'" height="'+h+'">');  
document.write('<param name="movie" value="'+ur+'">');  
document.write('<param name="quality" value="high"> ');  
document.write('<param name="wmode" value="transparent"> ');  
document.write('<param name="menu" value="false"> ');  
document.write('<embed src="'+ur+'" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" name="obj1" width="'+w+'" height="'+h+'" quality="High" wmode="transparent">');  
document.write('</embed>');  
document.write('</object>');  
} 
function noad2010(){
	if (getCookie("jb51ad2010")=="noad"){
		alert('广告已经关闭，请刷新下页面即可看到效果。');
		}else{	
	setCookie("jb51ad2010","noad",180);
alert("恭喜,已成功屏蔽广告,只要不清空Cookie,您都不会再受广告困扰！");
}}
function yesad2010(){
setCookie("jb51ad2010","yesad",180);
alert("您已经恢复到脚本之家广告版，谢谢您对我们的支持！");
}
var jsallstr=jsdown+jsad2;
function setCookie(name, value)		//cookies设置JS
{
	var argv = setCookie.arguments;
	var argc = setCookie.arguments.length;
	var expires = (argc > 2) ? argv[2] : null;
	if(expires!=null)
	{
		var LargeExpDate = new Date ();
		LargeExpDate.setTime(LargeExpDate.getTime() + (expires*1000*3600*24));
	}
	document.cookie = name + "=" + escape (value)+((expires == null) ? "" : ("; expires=" +LargeExpDate.toGMTString()))+"; path=/;";
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