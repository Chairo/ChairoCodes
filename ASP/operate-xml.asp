<%
m_path = Server.MapPath("test.xml")
SET m_objXML = Server.CreateObject("MSXML2.DOMDocument")
m_objXML.load m_path '����xml�ļ�

Set ns = m_objXML.selectNodes("//CODES/CODE") 'ѡ��ĳ�ڵ�
For i = 0 To ns.length-1
 'ns(i).SelectSingleNode("CODE").setAttribute "SearchIDs","typeYourName" 'CODE�ڵ��SearchIDs����ֵ��ΪtypeYourName
 Response.Write(ns(i).SelectSingleNode("//CODES/CODE[@CodeNameCn='����']/@SearchIDs").text) 'CODE�ڵ��CodeNameCn����ֵΪ"����"��SearchIDsֵ
Next

k = 0
For Each node In ns
 For i = 0 To node.attributes.length - 1
  Response.Write(node.attributes(i).nodeName&":"&node.attributes(i).value&"<br />") 'ѭ������CODE�ڵ���������ֺ�����ֵ
 Next
 k = k+1
Next

Response.Write m_objXML.selectSingleNode("//CODES").xml '���CODES�ڵ���ȫ��xml����

For Each n In ns
    Response.Write(n.selectSingleNode("@SearchIDs").text)
Next
%>