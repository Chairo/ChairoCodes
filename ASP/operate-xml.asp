<%
m_path = Server.MapPath("test.xml")
SET m_objXML = Server.CreateObject("MSXML2.DOMDocument")
m_objXML.load m_path '载入xml文件

Set ns = m_objXML.selectNodes("//CODES/CODE") '选择某节点
For i = 0 To ns.length-1
 'ns(i).SelectSingleNode("CODE").setAttribute "SearchIDs","typeYourName" 'CODE节点的SearchIDs属性值改为typeYourName
 Response.Write(ns(i).SelectSingleNode("//CODES/CODE[@CodeNameCn='安庆']/@SearchIDs").text) 'CODE节点的CodeNameCn属性值为"安庆"的SearchIDs值
Next

k = 0
For Each node In ns
 For i = 0 To node.attributes.length - 1
  Response.Write(node.attributes(i).nodeName&":"&node.attributes(i).value&"<br />") '循环所有CODE节点的属性名字和属性值
 Next
 k = k+1
Next

Response.Write m_objXML.selectSingleNode("//CODES").xml '获得CODES节点内全部xml内容

For Each n In ns
    Response.Write(n.selectSingleNode("@SearchIDs").text)
Next
%>