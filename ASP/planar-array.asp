<%
'�����ά�����С
ReDim myarray(3,1)
'��������
myarray(0,1) = "0"
myarray(0,0) = "<br>"
myarray(1,1) = "1"
myarray(1,0) = "<br>"
myarray(2,1) = "2"
myarray(2,0) = "<br>"
myarray(3,1) = "3"
myarray(3,0) = "<br>"
'ѭ����ά����
For i = 0 To UBound(myarray,1)
 Response.Write myarray(i,1)
 Response.Write myarray(i,0)
Next
%>