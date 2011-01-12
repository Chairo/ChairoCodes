    <%@ Language=VBScript %>
    <%
    Dim CmdSP
    Dim adoRS
    Dim adCmdSPStoredProc
    Dim adParamReturnValue
    Dim adParaminput
    Dim adParamOutput
    Dim adInteger
    Dim iVal
    Dim oVal
    Dim adoField
    Dim adVarChar
    '这些值在 VB 中是预定义常量，可以直接调用，但在 VBScript 中没有预定义
    adCmdSPStoredProc = 4
    adParamReturnValue = 4
    adParaminput = 1
    adParamOutput = 2
    adInteger = 3
    adVarChar = 200
    iVal = 5
    oVal = 3

    '建一个command对象
    set CmdSP = Server.CreateObject("ADODB.Command")
    '建立连结
    CmdSP.ActiveConnection = "Driver={SQL Server};server=(local);Uid=sa;Pwd=;Database=test"
    '定义command 对象调用名称
    CmdSP.CommandText = "sp_PubsTest"
    '设置command调用类型是存储过程 (adCmdSPStoredProc = 4)
    CmdSP.CommandType = adCmdSPStoredProc

    '往command 对象中加参数
    '定义存储过程有直接返回值，并且是个整数，省缺值是4
    CmdSP.Parameters.Append CmdSP.CreateParameter("RETURN_VALUE",adVarChar,adParamReturnValue,4)
    '定义一个字符型输入参数
    CmdSP.Parameters.Append CmdSP.CreateParameter("@au_lname",adVarChar,adParaminput,20,"test")
    '定义一个整型输入参数
    CmdSP.Parameters.Append CmdSP.CreateParameter("@intID",adInteger,adParamInput,,iVal)
    '定义一个整型输出参数
    CmdSP.Parameters.Append CmdSP.CreateParameter("@intIDOut",adInteger,adParamOutput,oVal)
    '运行存储过程，并得到返回记录集
    Set adoRS = CmdSP.Execute
    '把每个记录打印出来，其中的字段是虚拟的，可以不用管
    While Not adoRS.EOF
     for each adoField in adoRS.Fields
      Response.Write adoField.Name&"="&adoField.Value&"<br>"&vbCRLF
      Next
      Response.Write "<br>"
     adoRS.MoveNext
    Wend
    Set adoRS = nothing    '网上其他例子这个都放在最后边了...这样下边打印两个输出值就是空白了..
    '打印两个输出值：
    Response.Write CmdSP.Parameters("@intIDOut")
    Response.Write CmdSP.Parameters("RETURN_VALUE")
    '大扫除
    Set adoRS = nothing
    Set CmdSP.ActiveConnection = nothing
    Set CmdSP = nothing
    %>

Used storage process:

    CREATE PROCEDURE dbo.sp_PubsTest
        (
         @au_lname varchar(255),
         @intID int OUTPUT,
         @intIDOut int OUTPUT
        )
        AS
    SELECT @intIDOut =  1
        BEGIN
         Select * From dbo.authors Where au_lname = @au_lname

         RETURN @intIDOut+2
        END
    GO