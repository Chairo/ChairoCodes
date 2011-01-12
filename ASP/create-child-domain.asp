达到二级名的效果，必须一下条件以及流程：
1、必须有一个顶级域名，而且此域名必须做好泛解析并做好指向。
2、必须有一台独立的服务器。泛解析的域名指向该服务器。
3、在服务器上的IIS建一个空的主机头名的web站点。
4、将默认的页面设置为你的二机解析程序（比如：freedns.asp）
5、二级域名系列程序（包括申请页：shenqing.htm，添加页add.asp,解析页，）

此程序的优点：
a，可以限制申请域名的敏感字,比如 hacker,wwww,sex,china等
b, 可以限制申请域名的非法字，比如：！·#￥%……—*（）——？‘“/等
c, 每个地址只能申请一个域名。
d，限制申请域名的长度，
e, 如果用户所访问的域名没人申请则转到特定的页面，本例中的http://www.qx5.cn/miss.html
f, 申请了域名：***.yourname.com 可以同时支持：http://***.yourname.com 以及http://www.***.youranme.com 两个域名的访问。
一下为系列程序代码：
shenqing.htm

<form action=adddns.asp method=post name=Frm onSubmit="return check_input()"> <br> <font color=red>加*号为必填内容</font> <br>
您想注册的域名：
http://<inputname="nowurl"size=12
style=" BORDER-BOTTOM: 1px double; BORDER-LEFT: 1px double; BORDER-RIGHT: 1px double; BORDER-TOP: 1px double; COLOR: #000000; FONT-SIZE: 9pt"> .51bxg.com
　　　　 <br>
你实际的网站地址：
<input name="tourl" size=12
style=" BORDER-BOTTOM: 1px double; BORDER-LEFT: 1px double; BORDER-RIGHT: 1px double; BORDER-TOP: 1px double; COLOR: #000000; FONT-SIZE: 9pt">
你要求显示的title：
<input name="company" size=12
style=" BORDER-BOTTOM: 1px double; BORDER-LEFT: 1px double; BORDER-RIGHT: 1px double; BORDER-TOP: 1px double; COLOR: #000000; FONT-SIZE: 9pt">
<br>
<input type="submit" name="Submit" value=" 提 交 信 息 " style="border:1px double rgb(88,88,88);font:9pt">
　　
<input type="reset" name="Reset" value=" 重 新 填 写 " style="border:1px double rgb(88,88,88);font:9pt">
</p>
</form>
添加记录页面add.asp
<!--#include file="char.inc"-->
<!--#include file="conn.asp"-->
<%
uID=request.cookies("*****")
%>
<%
dim nowurl,tourl,company,along,pbkey
nowurl=trim(request.form("nowurl"))+".51bxg.com"
nurl=trim(request.form("nowurl"))
tourl=trim(request.form("tourl"))
company=trim(request.form("company"))
along=20
pbkey="www,sex,admin,w,ww,wwww,hacker,hack"
set rs=server.createobject("adodb.recordset")
sql="select * from dns where userid='"&uid&"'"
rs.open sql,conn,1,1
if not rs.EOF then
response.write"很抱歉，你已经申请过二级域名，每个用户只能申请一个二级域名！<br>你申请的二级域名是：http://"+rs("nowurl")
response.end
end if
set rs=server.createobject("adodb.recordset")
sql="select * from dns where nowurl='"&nowurl&"'"
rs.open sql,conn,1,1
if not rs.eof then
response.write"很抱歉，你申请的域名：http://"+nowurl+" 已经被其他公司申请，请另外申请域名。"
response.end
end if

if len(nurl)>along then
response.write"很抱歉，你输入的域名太长，请重新输入"
response.end
end if

if instr(pbkey,nurl) then
response.write"很抱歉，你输入的域名因为含有敏感字而不管理员屏蔽，请重新输入。"
response.end
end if

'判断字符的合法性
if instr(nurl,"~") or instr(nurl,"`") or instr(nurl,"/") or instr(nurl,"?") or instr(nurl,">") or instr(nurl,"<") or instr(nurl,";") or instr(nurl,":") or instr(nurl,"}") or instr(nurl,"{") or instr(nurl,")") or instr(nurl,"(") or instr(nurl,"*") or instr(nurl,"&") or instr(nurl,"^") or instr(nurl,"%") or instr(nurl,".") or instr(nurl,",") or instr(nurl,"'") or instr(nurl,"~") or instr(nurl,"!") or instr(nurl,"$") then
response.write"很抱歉，你输入的域名含有非法字符，请重新输入，以下字符为非法字符：<br>~ ` / ? > < ; : } { ) ( * & ^ % $ # @ ! "
response.end
end if
set rs=server.createobject("adodb.recordset")
sql="select * from ** where theid is null"
rs.open sql,conn,3,3
rs.addnew
rs("userid")=uID
rs("nowurl")=nowurl
rs("tourl")=tourl
rs("company")=company
rs.update
response.write"祝贺，申请成功，你马上就可使用你的域名：http://"+nowurl
%>
域名解吸程序： freedns.asp
<!--#include file="conn.asp"-->
<%
dim geturl
geturl=replace(Request.ServerVariables("HTTP_HOST"),"www.","")

set rs=server.createobject("adodb.recordset")
sql="select * from tb where nowurl='"&geturl&"'"
rs.open sql,conn,1,1
if rs.eof then
response.redirect"http://www.qx5.cn/miss.html"
else
dim tourl,company
tourl=rs("tourl")
company=rs("company")
%>
<HTML>
<HEAD>
<META http-equiv="Content-Type" content="text/html; charset=gb2312">
<META CONTENT="text/html; CHARSET=UTF-8" HTTP-EQUIV="Content-Type">
<TITLE><% =company %></TITLE>
</HEAD>
<frameset frameborder="0" framespacing="0" scrolling="no" border="0" marginheight="0" marginwidth="0" rows="0,*">
<frame scrolling="NO" noresize="0" marginwidth="0" marginheight="0" framespacing="0" frameborder="0" target="main" name="main" src="about:blank" mce_src="about:blank">

<frame scrolling="yes" noresize="0" marginwidth="0" marginheight="0" framespacing="0" frameborder="0" target="main" name="main" SRC="<% =tourl %>">

<noframes>
<body>
<p>This page uses frames, but your browser doesn't support them.</p></body>
</noframes>
</frameset>
</HTML>
<% end if %>