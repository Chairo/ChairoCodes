<%
    Class Wyd_AspCodeHighLight
    Private RegEx
    Public Keyword,ObjectCommand,Strings,VBCode
    Public KeyWordColor,ObjectCommandColor,StringsColor,Comment,CodeColorPrivate Sub Class_Initialize() '类初始化
    Set RegEx = New RegExp
    RegEx.IgnoreCase = True '设置是否区分字母的大小写 True 不区分。
    RegEx.Global = True '设置全程性质。
    KeyWordColor="#0000FF"
    ObjectCommandColor="#FF0000"
    StringsColor="#FF00FF"
    Comment="#008000"
    CodeColor="#993300"
    Keyword="Set|Private|If|Then|Sub|End|Function|For|Next|Do|While|Wend|True|False|Nothing|Class" ''关建字 请自己添加
    ObjectCommand="Left|Mid|Right|Int|Cint|Clng|String|Join|Array" ''函数 请自己添加
    VBCode=""
    End SubPrivate Sub Class_Terminate() '类注销
    Set RegEx = Nothing
    End SubPrivate Function M_Replace(Str,Pattern,Color)
    RegEx.Pattern = Pattern '' 设置模式。
    M_Replace=RegEx.Replace(Str,"$1")
    End Function

    Private Function String_Replace(Str,Pattern,Pattern1,Color,IsString)
    Dim Temp,RetStr
    RegEx.Pattern =Pattern1
    Set Matches = RegEx.Execute(Str)
    For Each Match In Matches '' 遍历 Matches 集合
    Temp=Re(Match.value)
    Str = Replace(Str,Match.value,Temp)
    Next
    RegEx.Pattern = Pattern '' 设置模式。
    If IsString=1 Then
    String_Replace=RegEx.Replace(Str,"$1")
    Else
    String_Replace=RegEx.Replace(Str,"$1")
    End If
    End Function

    Private Function Re(Str)
    Dim TRegEx,Temp
    Set TRegEx = New RegExp
    TRegEx.IgnoreCase = True '' 设置是否区分字母的大小写。
    TRegEx.Global = True '' 设置全程性质。
    TRegEx.Pattern="<.*?>"
    Temp=TRegEx.Replace(Str,"")
    Temp=Replace(Temp,"<","")
    Temp=Replace(Temp,">","")
    Re=Temp
    Set TRegEx=Nothing
    End Function

    Public Function MakeLi()
    Dim Temp
    If VBCode="" Then
    MakeLi=""
    Exit Function
    End If
    VBCode=HTMLEncode(VBCode)
    Temp=M_Replace(VBCode,"\b("&Keyword&")\b",KeyWordColor)
    Temp=M_Replace(Temp,"\b("&ObjEctCommand&")\b",ObjectCommandColor)
    Temp=String_Replace(Temp,"""(.*?)""","""(.*)(<.+?>)("&KeyWord&ObjectCommand&")+(<.+?>)(.*)""",StringsColor,1)'' 字符串
    Temp=String_Replace(Temp,"((''|rem).*)","''(.*)(<.+?>)("&KeyWord&ObjectCommand&")+(<.+?>)(.*)",Comment,0) ''注释
    MakeLi=""&RepVbCrlf(Temp)&""
    End Function

    Public Function RepVbCrlf(fString) '换行换成

    RepVbCrlf = Replace(fString, CHR(10), "
    ")
    End Function

    Public Function HTMLEncode(fString)
    If IsNull(fString) Or fString="" Then
    HTMLEncode=""
    Exit Function
    End If
    fString = replace(fString, ">", ">")
    fString = replace(fString, "<", "<")
    ''fString = Replace(fString, CHR(32), " ")
    ''fString = Replace(fString, CHR(9), " ")
    ''fString = Replace(fString, CHR(34), """)
    ''fString = Replace(fString, CHR(39), "''")
    ''fString = Replace(fString, CHR(13), "")
    ''fString = Replace(fString, CHR(10) & CHR(10), "

    ")
    ''fString = Replace(fString, CHR(10), "
    ")
    HTMLEncode = fString
    End Function
    End Class

用法:
Set TT = New Wyd_AspCodeHighLight
TT.VBCode="需要高亮部分代码"
Response.write TT.MakeLi()
%>