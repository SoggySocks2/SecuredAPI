CREATE TABLE [dbo].[Role]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [NormalizedName] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(250) NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] UNIQUEIDENTIFIER NOT NULL
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Role_NormalizedName]
    ON [dbo].[Role]([NormalizedName] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Role_IsDeleted]
    ON [dbo].[Role]([IsDeleted]);