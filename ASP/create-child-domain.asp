�ﵽ��������Ч��������һ�������Լ����̣�
1��������һ���������������Ҵ������������÷�����������ָ��
2��������һ̨�����ķ�������������������ָ��÷�������
3���ڷ������ϵ�IIS��һ���յ�����ͷ����webվ�㡣
4����Ĭ�ϵ�ҳ������Ϊ��Ķ����������򣨱��磺freedns.asp��
5����������ϵ�г��򣨰�������ҳ��shenqing.htm�����ҳadd.asp,����ҳ����

�˳�����ŵ㣺
a��������������������������,���� hacker,wwww,sex,china��
b, �����������������ķǷ��֣����磺����#��%������*��������������/��
c, ÿ����ַֻ������һ��������
d���������������ĳ��ȣ�
e, ����û������ʵ�����û��������ת���ض���ҳ�棬�����е�http://www.qx5.cn/miss.html
f, ������������***.yourname.com ����ͬʱ֧�֣�http://***.yourname.com �Լ�http://www.***.youranme.com ���������ķ��ʡ�
һ��Ϊϵ�г�����룺
shenqing.htm

<form action=adddns.asp method=post name=Frm onSubmit="return check_input()"> <br> <font color=red>��*��Ϊ��������</font> <br>
����ע���������
http://<inputname="nowurl"size=12
style=" BORDER-BOTTOM: 1px double; BORDER-LEFT: 1px double; BORDER-RIGHT: 1px double; BORDER-TOP: 1px double; COLOR: #000000; FONT-SIZE: 9pt"> .51bxg.com
�������� <br>
��ʵ�ʵ���վ��ַ��
<input name="tourl" size=12
style=" BORDER-BOTTOM: 1px double; BORDER-LEFT: 1px double; BORDER-RIGHT: 1px double; BORDER-TOP: 1px double; COLOR: #000000; FONT-SIZE: 9pt">
��Ҫ����ʾ��title��
<input name="company" size=12
style=" BORDER-BOTTOM: 1px double; BORDER-LEFT: 1px double; BORDER-RIGHT: 1px double; BORDER-TOP: 1px double; COLOR: #000000; FONT-SIZE: 9pt">
<br>
<input type="submit" name="Submit" value=" �� �� �� Ϣ " style="border:1px double rgb(88,88,88);font:9pt">
����
<input type="reset" name="Reset" value=" �� �� �� д " style="border:1px double rgb(88,88,88);font:9pt">
</p>
</form>
��Ӽ�¼ҳ��add.asp
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
response.write"�ܱ�Ǹ�����Ѿ����������������ÿ���û�ֻ������һ������������<br>������Ķ��������ǣ�http://"+rs("nowurl")
response.end
end if
set rs=server.createobject("adodb.recordset")
sql="select * from dns where nowurl='"&nowurl&"'"
rs.open sql,conn,1,1
if not rs.eof then
response.write"�ܱ�Ǹ���������������http://"+nowurl+" �Ѿ���������˾���룬����������������"
response.end
end if

if len(nurl)>along then
response.write"�ܱ�Ǹ�������������̫��������������"
response.end
end if

if instr(pbkey,nurl) then
response.write"�ܱ�Ǹ���������������Ϊ���������ֶ�������Ա���Σ����������롣"
response.end
end if

'�ж��ַ��ĺϷ���
if instr(nurl,"~") or instr(nurl,"`") or instr(nurl,"/") or instr(nurl,"?") or instr(nurl,">") or instr(nurl,"<") or instr(nurl,";") or instr(nurl,":") or instr(nurl,"}") or instr(nurl,"{") or instr(nurl,")") or instr(nurl,"(") or instr(nurl,"*") or instr(nurl,"&") or instr(nurl,"^") or instr(nurl,"%") or instr(nurl,".") or instr(nurl,",") or instr(nurl,"'") or instr(nurl,"~") or instr(nurl,"!") or instr(nurl,"$") then
response.write"�ܱ�Ǹ����������������зǷ��ַ������������룬�����ַ�Ϊ�Ƿ��ַ���<br>~ ` / ? > < ; : } { ) ( * & ^ % $ # @ ! "
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
response.write"ף�أ�����ɹ��������ϾͿ�ʹ�����������http://"+nowurl
%>
������������ freedns.asp
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