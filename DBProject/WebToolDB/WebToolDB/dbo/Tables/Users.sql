CREATE TABLE [dbo].[Users] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (50)  NOT NULL,
    [Password]     NVARCHAR (100) NULL,
    [CreationDate] DATETIME       NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_UserName]
    ON [dbo].[Users]([UserName] ASC);

