<%
'�����༶Ŀ¼�����Դ��������ڵĸ�Ŀ¼
'������Ҫ������Ŀ¼���ƣ������Ƕ༶
'�����߼�ֵ��True�ɹ���Falseʧ��
'����Ŀ¼�ĸ�Ŀ¼�ӵ�ǰĿ¼��ʼ
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

'ʹ�÷�����

Response.Write CreateMultiFolder("/upload/2005/3/26/") &"<br>"

Response.Write CraeteMultiFolder("upload2005326")

'�����ķ���ֵΪTrue(�ɹ�)��False(ʧ�ܣ�������������֧��FSO����) 

