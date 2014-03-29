CREATE TABLE [dbo].[WOL] (
    [WOLID]      INT           IDENTITY (1, 1) NOT NULL,
    [UserId]     INT           NOT NULL,
    [WOLName]    NVARCHAR (50) NULL,
    [MACAddress] NVARCHAR (20) NULL,
    [SubnetMask] NVARCHAR (20) NULL,
    [HostName]   NVARCHAR (50) NULL,
    [Port]       INT           NULL,
    [Protocol]   NVARCHAR (20) NULL,
    CONSTRAINT [PK_WOL] PRIMARY KEY CLUSTERED ([WOLID] ASC),
    CONSTRAINT [FK_WOL_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);




GO
CREATE NONCLUSTERED INDEX [IX_WOL_UserId]
    ON [dbo].[WOL]([UserId] DESC);


GO
CREATE NONCLUSTERED INDEX [IX_WOL_WOLName]
    ON [dbo].[WOL]([WOLName] ASC);

