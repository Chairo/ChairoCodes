<%
'使用Response.IsClientConnected是观察用户是否仍连到服务器并正在载入ASP创建的网页的有用方式
If Response.IsClientConnected Then
    Response.Flush
Else
    Response.End
End If
%>