CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(500) NOT NULL,
	[Category_Id] INT NOT NULL,
	[IsDone] BIT NOT NULL, 
    CONSTRAINT [FK_Tasks_ToCategories] FOREIGN KEY ([Category_Id]) REFERENCES [Categories]([Id])
)
