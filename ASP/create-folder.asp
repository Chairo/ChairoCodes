<%
'创建多级目录，可以创建不存在的根目录
'参数：要创建的目录名称，可以是多级
'返回逻辑值，True成功，False失败
'创建目录的根目录从当前目录开始
'---------------------------------------------------
Function CreateMultiFolder(ByVal CFolder)
Dim objFSO,PhCreateFolder,CreateFolderArray,CreateFolder
Dim i,ii,CreateFolderSub,PhCreateFolderSub,BlInfo
BlInfo = False
CreateFolder = CFolder
On Error Resume Next
Set objFSO = Server.CreateObject("Scripting.FileSystemObject")
If Err Then
Err.Clear()
Exit Function
End If
CreateFolder = Replace(CreateFolder,"","/")
If Left(CreateFolder,1)="/" Then
CreateFolder = Right(CreateFolder,Len(CreateFolder)-1)
End If
If Right(CreateFolder,1)="/" Then
CreateFolder = Left(CreateFolder,Len(CreateFolder)-1)
End If
CreateFolderArray = Split(CreateFolder,"/")
For i = 0 to UBound(CreateFolderArray)
CreateFolderSub = ""
For ii = 0 to i
CreateFolderSub = CreateFolderSub & CreateFolderArray(ii) & "/"
Next
PhCreateFolderSub = Server.MapPath(CreateFolderSub)
If Not objFSO.FolderExists(PhCreateFolderSub) Then
objFSO.CreateFolder(PhCreateFolderSub)
End If
Next
If Err Then
Err.Clear()
Else
BlInfo = True
End If
CreateMultiFolder = BlInfo
End Function
%>

'使用方法：

Response.Write CreateMultiFolder("/upload/2005/3/26/") &"<br>"

Response.Write CraeteMultiFolder("upload2005326")

'函数的返回值为True(成功)或False(失败，可以是主机不支持FSO功能) 

