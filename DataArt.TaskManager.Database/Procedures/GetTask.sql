CREATE PROCEDURE [dbo].[GetTask]
	@id INT
AS
BEGIN
	SELECT Tasks.Id, Title, IsDone, Categories.Id, Name
	FROM Tasks 
		JOIN Categories ON Tasks.Category_Id = Categories.Id
	WHERE Tasks.Id = @id;
END
