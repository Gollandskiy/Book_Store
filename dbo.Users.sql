CREATE TABLE [dbo].[Users] (
    [ID]       UNIQUEIDENTIFIER NOT NULL,
    [Username] NVARCHAR (20)   NOT NULL,
    [Password] NVARCHAR (20)   NOT NULL,
    [Email]    NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

