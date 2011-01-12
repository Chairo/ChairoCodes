<%
'如果出错显示
On Error GoTo 0

'出错不显示.跳过错误执行下一行
On Error Resume Next

'强制声明变量打开,如果变量不声明则出错误
Option Explicit

'Asp程序缓冲区打开
Response.Buffer = True

'设置Session失效时间
Session.Timeout = 20

'设置页面语言(ANSI代码页为1252，日文代码页为932，简体中文代码页为936, UTF-8为65001)
<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>

'获得页面来源地址
Request.ServerVariables("HTTP_REFERER")   
%>

