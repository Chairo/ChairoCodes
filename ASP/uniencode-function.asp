<%
Function Encode(Str)
 Dim Count, Pos, Ch, Code
 Dim SweetCh
 
 'SweetCh中表示不需要进行编码的字符
 SweetCh = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz_{}[]()"
 Encode = ""
 
 Count = Len(Str)
 Pos = 1
 Do While Pos<=Count
  Ch = Mid(Str, Pos, 1)
  
  Code = Asc(Ch)
  If Code>=0 And Code<256 Then  '汉字不予处理
   If Ch<>"%" Then
    If InStr(SweetCh, Ch)=0 Then
     Ch = "%" & Right("0" & Hex(Code), 2)
    End If
   Else
    Ch = "%25"
   End If
  End If
  
  Encode = Encode & Ch
  Pos = Pos + 1
 Loop
End Function

Function Decode(Str)
 Dim Count, Pos, Ch, Code
 
 Decode = ""
 
 Count = Len(Str)
 Pos = 1
 Do While Pos<=Count
  Ch = Mid(Str, Pos, 1)
  If Ch="%" Then
   If Pos+2<=Count Then
    Ch = Chr((InStr("0123456789ABCDEF", UCase(Mid(Str, Pos+1, 1)))-1) * 16 + InStr("0123456789ABCDEF",UCase(Mid(Str, Pos+2, 1))) - 1)
   Else
    '编码串不正确
    Ch = ""
   End If
   Pos = Pos + 2
  End If
  Decode = Decode & Ch
  Pos = Pos + 1
 Loop
End Function

%>
