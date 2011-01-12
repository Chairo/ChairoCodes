<%
'===================================
'数据库操作类
'===================================
'名称：Class_DBOperate
'版本：0.2
'作者：qihangnet
'更新：2005年6月14日
'作用：简化数据库操作的流程
'授权：免费使用
'===================================

Class Class_DBOperate

'************************************
'变量定义
'************************************
'Conn ---------- 数据库连接对象
'Conn_Str ------ 数据库连接字符串

Private Conn,Conn_Str

'类初始化
Private Sub Class_Initialize()
    Set Conn = Server.CreateObject("ADODB.Connection")
End Sub

'类注销触发
Private Sub Class_Teriminate()
    'Set Conn = Nothing
End Sub

'************************************
'属性
'************************************

'输出数据库连接字符串
' 返回值类型：string

Property Get ConnectString()
    ConnectString = Conn_Str
End Property

'设置数据库连接字符串（数据库连接字符串）
' 参数：str --- string

Property Let ConnectString(str)
    Conn_Str = str
End Property

'************************************
'事件
'************************************

'数据库打开
Public Sub DB_Open()
    'Conn.ConnectionString = Conn_Str
    Conn.Open ConnectString
End Sub

'数据库关闭
Public Sub DB_Close()
    Conn.Close
    Set Conn = Nothing
End Sub

'************************************
'方法
'************************************

'数据库查询（sql语句）
' 参数及类别：sql ---- string
' 返回值类型：记录集
' 前提：数据库状态为打开

Public Function DB_Select(sql)
    Set DB_Select = Conn.Execute(sql)
End Function

'数据库执行（SQL语句）
' 参数及类别：sql ---- string
' 返回值类型：整形
' 返回值含义：受影响行数
' 前提：数据库状态为打开

Public Function DB_Excute(sql)
    Dim rs_affected
    Conn.Execute sql,rs_affected
    DB_Excute = rs_affected
End Function

End Class
%>
<%
dbdns="./"
ORI_db=dbdns&"data/#ORI_free_info.mdb"   'dbdns 为各文件中设置的路径，请不要改动
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