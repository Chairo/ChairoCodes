E:\NET\WebApp>wsdl /out:service.cs http://localhost/test/Service1.asmx?WSDL

csc \targer:library\out: "c:\1.dll" "c:\1.cs"

csc   /t:library   test.cs

web���ú�using web��������.�����ռ�; Ȼ��web���õ��� ʵ����=new web���õ���();

��webserviceΪweb�����namespace,service1Ϊ��,��������Ϊlocalhost��

using localhost.webservice;

service1 wes = new service1();

string sum=wes.Add(3,5).ToString();

Response.Write(sum);