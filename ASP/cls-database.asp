<%
'===================================
'���ݿ������
'===================================
'���ƣ�Class_DBOperate
'�汾��0.2
'���ߣ�qihangnet
'���£�2005��6��14��
'���ã������ݿ����������
'��Ȩ�����ʹ��
'===================================

Class Class_DBOperate

'************************************
'��������
'************************************
'Conn ---------- ���ݿ����Ӷ���
'Conn_Str ------ ���ݿ������ַ���

Private Conn,Conn_Str

'���ʼ��
Private Sub Class_Initialize()
    Set Conn = Server.CreateObject("ADODB.Connection")
End Sub

'��ע������
Private Sub Class_Teriminate()
    'Set Conn = Nothing
End Sub

'************************************
'����
'************************************

'������ݿ������ַ���
' ����ֵ���ͣ�string

Property Get ConnectString()
    ConnectString = Conn_Str
End Property

'�������ݿ������ַ��������ݿ������ַ�����
' ������str --- string

Property Let ConnectString(str)
    Conn_Str = str
End Property

'************************************
'�¼�
'************************************

'���ݿ��
Public Sub DB_Open()
    'Conn.ConnectionString = Conn_Str
    Conn.Open ConnectString
End Sub

'���ݿ�ر�
Public Sub DB_Close()
    Conn.Close
    Set Conn = Nothing
End Sub

'************************************
'����
'************************************

'���ݿ��ѯ��sql��䣩
' ���������sql ---- string
' ����ֵ���ͣ���¼��
' ǰ�᣺���ݿ�״̬Ϊ��

Public Function DB_Select(sql)
    Set DB_Select = Conn.Execute(sql)
End Function

'���ݿ�ִ�У�SQL��䣩
' ���������sql ---- string
' ����ֵ���ͣ�����
' ����ֵ���壺��Ӱ������
' ǰ�᣺���ݿ�״̬Ϊ��

Public Function DB_Excute(sql)
    Dim rs_affected
    Conn.Execute sql,rs_affected
    DB_Excute = rs_affected
End Function

End Class
%>
<%
dbdns="./"
ORI_db=dbdns&"data/#ORI_free_info.mdb"   'dbdns Ϊ���ļ������õ�·�����벻Ҫ�Ķ�
set db = new Class_DBOperate
db.ConnectString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="&Server.MapPath(ORI_db)
db.DB_Open
DB_Select=db.DB_Select("Select * From ORI_admin")
DB_Excute=db.DB_Excute("Insert Into ORI_admin (ORI_login_name) Values ('Test')")
DB_Excute=db.DB_Excute("Update ORI_admin Set ORI_login_name='Test2' Where ORI_login_name='test'")
Response.Write(DB_Excute)
'Response.Write(DB_Select("ORI_id"))
If err.Number<>0 Then
    Response.Write(db.ConnectString)
End If
db.DB_Close
%>