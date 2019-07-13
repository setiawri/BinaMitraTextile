
SELECT * INTO #TEMP from vendorinvoices ORDER BY invoice_no ASC

DECLARE @datetime datetime
SELECT @datetime = GETDATE() --get date only without time

DECLARE @id uniqueidentifier
WHILE EXISTS(SELECT * FROM #TEMP)
BEGIN
	SELECT TOP 1 @id = id FROM #TEMP

	SET @datetime = DATEADD(ss,1,@datetime) --add 1 second to previous datetime
	update vendorinvoices set timestamp = @datetime WHERE id=@id --set value

	DELETE #TEMP WHERE id=@id
END

DROP TABLE #TEMP --delete table

SELECT * FROM VendorInvoices
