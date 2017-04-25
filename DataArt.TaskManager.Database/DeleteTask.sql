CREATE PROCEDURE [dbo].[DeleteTask]
	@id int
AS
BEGIN
	DELETE FROM Tasks WHERE Id = @id;
END
