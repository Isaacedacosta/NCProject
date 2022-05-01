CREATE TABLE [dbo].[Locations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NCHAR(40) NOT NULL, 
    [Descricao] NCHAR(100) NOT NULL, 
    [Localizacao] NCHAR(40) NOT NULL, 
    [Cidade] NCHAR(30) NOT NULL, 
    [Estado] CHAR(2) NOT NULL, 
    [Data] DATETIME2(1) NOT NULL
)
