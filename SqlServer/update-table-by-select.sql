UPDATE test1 SET ID = 0
FROM test1 INNER JOIN a ON a.a = test1.name

UPDATE test1 SET ID = b.number
FROM test1
INNER JOIN (SELECT a, COUNT(a) as number FROM a GROUP BY a) b ON test1.name = b.a