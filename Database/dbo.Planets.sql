CREATE TABLE [dbo].[Planets] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Class]       VARCHAR (3)  NOT NULL,
    [Coordinates] VARCHAR (50) NOT NULL,
    [Purpose]     VARCHAR (50) NOT NULL,
    [Name]        VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

