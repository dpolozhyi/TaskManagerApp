CREATE PROCEDURE [dbo].[EditTask]
	@taskId INT,
	@title NVARCHAR(500),
	@categoryId INT,
	@isDone BIT
AS
BEGIN
	UPDATE Tasks
	SET Title = @title, Category_Id = @categoryId, IsDone = @isDone
	WHERE Id = @taskId;
END