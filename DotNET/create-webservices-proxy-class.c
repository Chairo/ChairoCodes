E:\NET\WebApp>wsdl /out:service.cs http://localhost/test/Service1.asmx?WSDL

csc \targer:library\out: "c:\1.dll" "c:\1.cs"

csc   /t:library   test.cs

web引用后using web引用名字.命名空间; 然后web引用的类 实例化=new web引用的类();

如webservice为web服务的namespace,service1为类,引用名字为localhost则

using localhost.webservice;

service1 wes = new service1();

string sum=wes.Add(3,5).ToString();

Response.Write(sum);