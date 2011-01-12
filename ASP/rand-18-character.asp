<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%><%
response.write "Ëæ»ú18×Ö·û´®"&makePassword(18)&"<br>"
Dim A
A=Array(100,3,4)
Response.Write(UBound(A,1))
Response.Write("<br>")
Response.Write(LBound(A,1))
'Randomize
'Response.Write(Cint(89*Rnd+10))

function makePassword(byVal maxLen)

Dim strNewPass
Dim whatsNext, upper, lower, intCounter
Randomize

For intCounter = 1 To maxLen
    whatsNext = Int((1 - 0 + 1) * Rnd + 0)
If whatsNext = 0 Then
        upper = 90
        lower = 65
Else
        upper = 57
        lower = 48
End If
        strNewPass = strNewPass & Chr(Int((upper - lower + 1) * Rnd + lower))
Next
        makePassword = strNewPass
      ' Ö¸¶¨×Ö·û·¶Î§

end function
%>
