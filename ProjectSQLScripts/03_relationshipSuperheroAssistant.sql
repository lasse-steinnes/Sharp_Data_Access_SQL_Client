USE SuperheroesDb

ALTER TABLE Assistant 
	ADD SuperheroId int FOREIGN KEY REFERENCES Superhero(HeroId)

USE master