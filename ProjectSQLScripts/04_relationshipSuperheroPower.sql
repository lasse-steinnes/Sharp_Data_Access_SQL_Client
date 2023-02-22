USE SuperheroesDb

CREATE TABLE SuperheroPowers (
	HeroId int FOREIGN KEY REFERENCES Superhero(HeroId),
	PowerId int FOREIGN KEY REFERENCES [Power](PowerId),
	PRIMARY KEY (HeroId, PowerId ));

USE master