USE pubs 
GO 
SELECT distinct pub_name 
FROM publishers 
WHERE pub_id IN 
   (SELECT pub_id 
   FROM titles 
   WHERE type = 'business') 
GO

USE pubs 
GO 
SELECT DISTINCT pub_name 
FROM publishers 
WHERE EXISTS 
   (SELECT * 
   FROM titles 
   WHERE pub_id = publishers.pub_id 
   AND type = 'business') 
GO

