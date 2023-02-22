USE SuperheroesDb

CREATE TABLE SuperheroPowers (
	HeroId int FOREIGN KEY REFERENCES Superhero(HeroId),
	PowerId int FOREIGN KEY REFERENCES [Power](PowerId),
	PRIMARY KEY (HeroId, PowerId ));

GO
USE SuperheroesDb	
ALTER TABLE [Power]
	ADD SuperHeroId int FOREIGN KEY  REFERENCES SuperheroPowers(HeroId)
GO
USE SuperheroesDb
ALTER TABLE Superhero
	ADD SuperPowerId int FOREIGN KEY  REFERENCES SuperheroPowers(PowerId)