<%
'/**
'*Action: Encrypt/decrypt a string
'*Input: $str
'*Comment:
'*Output:
'*CreatDate: 2007-10-30
'*Author: Origami
'*Update:
'*Example:Response.Write(1, 1, "ÏÔÊ¾", "LinkUrl")
'*/
Function p(dept, dep_num, title, url)
    If Mid(session("fla"&dept), dep_num, 1)="1" Then
        p="<a href="&url&" mce_href="&url&" class='left'>"&title&"</a>"
    Else
        p="<font style='font-size: 9pt; color: #999999'>"&title&"</font>"
    End If
End Function
%>