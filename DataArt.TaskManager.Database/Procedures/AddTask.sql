CREATE PROCEDURE [dbo].[AddTask]
	@title NVARCHAR(500),
	@categoryId INT,
	@isDone BIT
AS
BEGIN
	INSERT INTO Tasks(Title, Category_Id, IsDone) VALUES(@title, @categoryId, @isDone);
	SELECT CAST(SCOPE_IDENTITY() AS INT);
END
