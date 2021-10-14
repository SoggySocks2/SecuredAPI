CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(100) NULL, 
    [LastName] NVARCHAR(100) NULL, 
    [Email] NVARCHAR(250) NOT NULL, 
    [NormalizedEmail] NVARCHAR(250) NOT NULL, 
    [PreferredLanguageISOCode] NVARCHAR(10) NOT NULL, 
    [IsStaff] BIT NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] UNIQUEIDENTIFIER NOT NULL
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_User_NormalizedEmail]
    ON [dbo].[User]([NormalizedEmail]);

GO
CREATE NONCLUSTERED INDEX [IX_User_IsDeleted]
    ON [dbo].[User]([IsDeleted]);
