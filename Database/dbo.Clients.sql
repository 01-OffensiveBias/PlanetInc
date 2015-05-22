CREATE TABLE [dbo].[Clients] (
    [Id]             INT          NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [Start_Date]     DATE         NOT NULL,
    [End_Date]       DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

