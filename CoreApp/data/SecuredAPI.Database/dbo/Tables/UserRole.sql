CREATE TABLE [dbo].[UserRole]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL, 
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED (UserId, RoleId),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
)
GO

CREATE NONCLUSTERED INDEX [IX_UserRole_IsDeleted]
    ON [dbo].[UserRole]([IsDeleted]);