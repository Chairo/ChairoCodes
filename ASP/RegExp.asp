<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Test</title>
<link type="text/css" rel="alternate stylesheet" href="reset.css" />
</head>

<body>
<%
strTxt = Request.Form("txt")
Response.Write("原输入字符串: "&strTxt)
Response.Write("<br />")
Set regEx = New RegExp
regEx.Global = True    '设置全局替换
regEx.IgnoreCase = True    '设置是否区分大小写
regEx.MultiLine = True
regEx.Pattern = "[^\u4e00-\u9fa5]"    '设置匹配规则
strResult = regEx.Replace(strTxt, "")    '根据规则替换
Response.Write("根据正则规则替换后字符串: "&strResult)
Response.Write("<br />")
Set Matches = regEx.Execute(strTxt)    '根据规则匹配
For Each Match in Matches    ' 遍历 Matches 集合
	Response.Write("匹配位置: "&Match.FirstIndex&" 值: "&Match.Value)
	Response.Write("<br />")
Next
retVal = regEx.Test(strTxt)    '根据规则测试是否可以匹配到
If retVal Then
	Response.Write("找到一个或多个匹配")
Else
	Response.Write("未找到匹配")
End If
%>
<form action="test.asp" method="post" enctype="application/x-www-form-urlencoded" name="frmTest">
    <input type="text" name="txt" id="txt" value="测试test!@#" />
    <input type="submit" name="Submit" id="Submit" value="提交" /> 
</form>
</body>
</html>