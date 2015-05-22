CREATE TABLE [dbo].[Regions] (
    [Id]       INT        NOT NULL,
    [PlanetId] INT NOT NULL,
	[ClientId] INT NULL,
    [Terrain]  VARCHAR(50) NOT NULL,
    [Price]    MONEY      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [PlanetId] FOREIGN KEY ([Id]) REFERENCES [dbo].[Planets] ([Id]),
	CONSTRAINT [ClientId] FOREIGN KEY ([Id]) REFERENCES [dbo].[Clients] ([Id])
);

