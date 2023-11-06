CREATE TABLE [dbo].[Books] (
    [ID]            UNIQUEIDENTIFIER NOT NULL,
    [Name]          NVARCHAR (40)   NOT NULL,
    [Style]         NVARCHAR (30)   NOT NULL,
    [NameAuthor]    NVARCHAR (20)   NOT NULL,
    [SubnameAuthor] NVARCHAR (30)   NOT NULL,
    [Price]         REAL             NOT NULL,
    [Description]   NVARCHAR (MAX)   NOT NULL,
    [Image]         NVARCHAR (MAX)   DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([ID] ASC)
);

