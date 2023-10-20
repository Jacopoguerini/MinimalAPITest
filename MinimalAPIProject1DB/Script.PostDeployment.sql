IF NOT EXISTS (SELECT 1 FROM dbo.[User])
BEGIN
	INSERT INTO dbo.[User] (FirstName, LastName)
	VALUES ('Tim', 'Corey'),
		('Sue', 'Storm'),
		('John', 'Smith'),
		('Mary', 'Jones');
END