CREATE PROCEDURE GetTasksList
AS
BEGIN
	SELECT Tasks.Id, Title, IsDone, Categories.Id, Name 
	FROM Tasks 
		JOIN Categories ON Tasks.Category_Id = Categories.Id;
END