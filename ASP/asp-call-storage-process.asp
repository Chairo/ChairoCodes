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
    '��Щֵ�� VB ����Ԥ���峣��������ֱ�ӵ��ã����� VBScript ��û��Ԥ����
    adCmdSPStoredProc = 4
    adParamReturnValue = 4
    adParaminput = 1
    adParamOutput = 2
    adInteger = 3
    adVarChar = 200
    iVal = 5
    oVal = 3

    '��һ��command����
    set CmdSP = Server.CreateObject("ADODB.Command")
    '��������
    CmdSP.ActiveConnection = "Driver={SQL Server};server=(local);Uid=sa;Pwd=;Database=test"
    '����command �����������
    CmdSP.CommandText = "sp_PubsTest"
    '����command���������Ǵ洢���� (adCmdSPStoredProc = 4)
    CmdSP.CommandType = adCmdSPStoredProc

    '��command �����мӲ���
    '����洢������ֱ�ӷ���ֵ�������Ǹ�������ʡȱֵ��4
    CmdSP.Parameters.Append CmdSP.CreateParameter("RETURN_VALUE",adVarChar,adParamReturnValue,4)
    '����һ���ַ����������
    CmdSP.Parameters.Append CmdSP.CreateParameter("@au_lname",adVarChar,adParaminput,20,"test")
    '����һ�������������
    CmdSP.Parameters.Append CmdSP.CreateParameter("@intID",adInteger,adParamInput,,iVal)
    '����һ�������������
    CmdSP.Parameters.Append CmdSP.CreateParameter("@intIDOut",adInteger,adParamOutput,oVal)
    '���д洢���̣����õ����ؼ�¼��
    Set adoRS = CmdSP.Execute
    '��ÿ����¼��ӡ���������е��ֶ�������ģ����Բ��ù�
    While Not adoRS.EOF
     for each adoField in adoRS.Fields
      Response.Write adoField.Name&"="&adoField.Value&"<br>"&vbCRLF
      Next
      Response.Write "<br>"
     adoRS.MoveNext
    Wend
    Set adoRS = nothing    '���������������������������...�����±ߴ�ӡ�������ֵ���ǿհ���..
    '��ӡ�������ֵ��
    Response.Write CmdSP.Parameters("@intIDOut")
    Response.Write CmdSP.Parameters("RETURN_VALUE")
    '��ɨ��
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