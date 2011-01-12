 ip地址与数字相互转换的sql函数
if   exists   (select   *   from   dbo.sysobjects   where   id   =   object_id(N'[dbo].[f_IP2Int]')   and   xtype   in   (N'FN',   N'IF',   N'TF'))   
  drop   function   [dbo].[f_IP2Int]   
  GO   
    
  /**//*--字符型   IP   地址转换成数字   IP   
    
  --邹建   2004.08(引用请保留此信息)--*/   
    
  /**//*--调用示例   
    
  select   dbo.f_IP2Int('192.168.0.11')   
  select   dbo.f_IP2Int('12.168.0.1')   
  --*/   
  CREATE   FUNCTION   f_IP2Int(   
  @ip   char(15)   
  )RETURNS   bigint   
  AS   
  BEGIN   
  DECLARE   @re   bigint   
  SET   @re=0   
  SELECT   @re=@re+LEFT(@ip,CHARINDEX('.',@ip+'.')-1)*ID   
  ,@ip=STUFF(@ip,1,CHARINDEX('.',@ip+'.'),'')   
  FROM(   
  SELECT   ID=CAST(16777216   as   bigint)   
  UNION   ALL   SELECT   65536   
  UNION   ALL   SELECT   256   
  UNION   ALL   SELECT   1)A   
  RETURN(@re)   
  END   
  GO   
    
    
    
  if   exists   (select   *   from   dbo.sysobjects   where   id   =   object_id(N'[dbo].[f_Int2IP]')   and   xtype   in   (N'FN',   N'IF',   N'TF'))   
  drop   function   [dbo].[f_Int2IP]   
  GO   
    
  /**//*--数字   IP   转换成格式化   IP   地址   
    
  --邹建   2004.08(引用请保留此信息)--*/   
    
  /**//*--调用示例   
    
  select   dbo.f_Int2IP(3232235531)   
  select   dbo.f_Int2IP(212336641)   
  --*/   
  CREATE   FUNCTION   f_Int2IP(   
  @IP   bigint   
  )RETURNS   varchar(15)   
  AS   
  BEGIN   
  DECLARE   @re   varchar(15)   
  SET   @re=''   
  SELECT   @re=@re+'.'+CAST(@IP/ID   as   varchar)   
  ,@IP=@IP%ID   
  from(   
  SELECT   ID=CAST(16777216   as   bigint)   
  UNION   ALL   SELECT   65536   
  UNION   ALL   SELECT   256   
  UNION   ALL   SELECT   1)a   
  RETURN(STUFF(@re,1,1,''))   
  END   

