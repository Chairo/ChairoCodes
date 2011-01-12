--Declare a variable
DECLARE @i int
SET @i = 1
WHILE @i<100
BEGIN
    INSERT INTO test (name) VALUES (@i)
    SET @i = @i + 1
    CONTINUE
END