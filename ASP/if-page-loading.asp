<%
'ʹ��Response.IsClientConnected�ǹ۲��û��Ƿ�����������������������ASP��������ҳ�����÷�ʽ
If Response.IsClientConnected Then
    Response.Flush
Else
    Response.End
End If
%>