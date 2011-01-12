DECLARE @name nvarchar(50)
--Declare a cursor and associate it to a transact sql
DECLARE Employee_Cursor CURSOR FOR
    SELECT TOP 10 name FROM test
--Open CURSOR
OPEN Employee_Cursor
--Get first data and impress to a variable
FETCH NEXT FROM Employee_Cursor INTO @name
--While fetch succeed
WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @name
        --Get next data and impress it to variable
        FETCH NEXT FROM Employee_Cursor INTO @name
    END
--Close cursor
CLOSE Employee_Cursor
--Destroy cursor
DEALLOCATE Employee_Cursor