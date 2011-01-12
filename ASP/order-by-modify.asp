<%
OPTION EXPLICIT 
Dim objFso, objFile, strFileNewName, strFileModifyDate, tmpArrFiles, i, j, objFiles, tt, folderPath, tmpArr
folderPath = "D:\asp\"
'获得目录下所有文件列表数组
tmpArr = arrFiles(folderPath)
'循环列表
For i = 0 To ubound(tmpArr) - 1
      Response.Write GetFileName(tmpArr(i))&"<br>"   
Next

Function arrFiles(strPath)
	Dim objFso, objFile, strFileNewName, strFileModifyDate, tmpArrFiles, i, j, objFiles, tt, strResult
	strFileNewName = ""
	Set objFso = Server.CreateObject("Scripting.filesystemobject")
	Set objFiles = objFso.Getfolder(strPath)
	'遍历目录
	For Each objFile In objFiles.Files
		strFileModifyDate = objFile.DateLastModified
		strFileNewName = strFileNewName&Year(strFileModifyDate)&Right("0"&Month(strFileModifyDate), 2)&Right("0"&Day(strFileModifyDate), 2)&Right("0"&Hour(strFileModifyDate), 2)&Right("0"&Minute(strFileModifyDate), 2)&Right("0"&Second(strFileModifyDate), 2)&"*"&objFile.Name&"|"
	Next
	'文件名分割成数组
	tmpArrFiles = Split(strFileNewName, "|")
	'冒泡排序文件名
	For j = 0 To UBound(tmpArrFiles)   
      strResult = ""   
      For i = 0 To UBound(tmpArrFiles)
          If i = UBound(tmpArrFiles) Then strResult = strResult&tmpArrFiles(i)&"|":Exit For	    '如果按修改时间倒序排序则Then后只保留Exit For
          If tmpArrFiles(i) >= tmpArrFiles(i + 1) Then     '如果按修改时间倒序排列,则<=
             tt = tmpArrFiles(i)
             tmpArrFiles(i) = tmpArrFiles(i + 1)
             tmpArrFiles(i + 1) = tt
          End If
          strResult = strResult&tmpArrFiles(i)&"|"   
      Next
	Next
	If Left(strResult, 1) = "|" Then strResult = Right(strResult, Len(strResult)-1)
	arrFiles = Split(strResult, "|")
End Function

Function GetFileName(str)
	Dim arrFileName
	arrFileName = Split(str, "*")
	GetFileName = arrFileName(1)
End Function
%> 