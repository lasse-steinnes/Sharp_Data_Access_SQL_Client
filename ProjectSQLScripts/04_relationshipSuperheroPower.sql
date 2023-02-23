USE SuperheroesDb

CREATE TABLE SuperheroPowers (
	SuperHeroId int,
	SuperPowerId int,
	PRIMARY KEY (SuperHeroId, SuperPowerId ));

ALTER TABLE SuperheroPowers
	ADD FOREIGN KEY (SuperHeroId) REFERENCES Superhero(HeroId)

ALTER TABLE SuperheroPowers
	ADD FOREIGN KEY (SuperPowerId)  REFERENCES [Power](PowerId)
