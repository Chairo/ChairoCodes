以前写过一些XMLHTTP的东西,好久不碰了,居然很多都忘记了

PS:修正中文乱码问题

conn.asp

    <%
    'Must announce the variable
    Option Explicit
    'If andy errors stop the program
    On Error GoTo 0
    'If error jump over it and keep on running the program
    'On Error Resume Next
    'Announce the variables
    Dim Conn,Sql,Rs,AccessPath,AccessFile
    AccessPath = "./" 'Must be end of /

    AccessFile = "test.mdb" 'The database filename
    Set Conn= Server.CreateObject("ADODB.Connection")
    Conn.ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source="&Server.MapPath(AccessPath&AccessFile)
    Conn.Open

    %>

search.asp

    <!--#include file="conn.asp" -->
    <%
    Dim tp,tt
    tp=Trim(Request.QueryString("ID"))
    Set Rs=Server.CreateObject("ADODB.RecordSet")
    Sql = "Select name From test Where id="&tp
    Rs.Open Sql,Conn,1,1
    If Not (Rs.Eof Or Rs.Bof) Then
     Response.Write(Rs("name"))
    Response.Write(Escape(Rs("name")))
    Else
     Response.Write("Null")
    End If
    Rs.Close()
    %>

index.asp

    <script language="javascript">
    function openUrl(url){
     if (window.XMLHttpRequest) { //IE之外的浏览器
    　　 objXmlHttp = new XMLHttpRequest();
    　　}else if(window.ActiveXObject){//IE 5.0 and up
    　　 objXmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    　　}
        objXmlHttp.open("GET",url,false);
        objXmlHttp.send();
     retInfo=objXmlHttp.responseText;
     if (objXmlHttp.status=="200"){
      info.innerHTML=retInfo;
      info.innerHTML=unescape(retInfo);
      return true;
     }else{
       return false;
     }
    }
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />  信息ID:
        <input type="text" name="ID" id="ID" onblur="openUrl('http://localhost/test/test/search.asp?ID='+this.value);"/>
     对应简介:  <span id="info" name="info"></span>
