USE SuperheroesDb

CREATE TABLE Superhero (
	HeroId int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL,
	alias nvarchar (50),
	origin nvarchar(400)
)
CREATE TABLE Assistant(
	AssistantId int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(50)
)
CREATE TABLE [Power] (
	PowerId int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(100),
	[Description] nvarchar(300)
)
USE master