﻿CREATE PROCEDURE [dbo].[DeleteTask]
	@id INT
AS
BEGIN
	DELETE FROM Tasks WHERE Id = @id;
END
