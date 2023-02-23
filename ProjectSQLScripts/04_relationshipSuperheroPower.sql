USE SuperheroesDb
/*Creates a new table, and set both columns to be a composite primary key*/
CREATE TABLE SuperheroPower (
	SuperheroId int,
	SuperPowerId int,
	PRIMARY KEY (SuperheroId, SuperPowerId ));
/* Add foreign keys to the columns, which opens up a many to many relationship*/
ALTER TABLE SuperheroPower
	ADD FOREIGN KEY (SuperheroId) REFERENCES Superhero(HeroId)

ALTER TABLE SuperheroPower
	ADD FOREIGN KEY (SuperPowerId)  REFERENCES [Power](PowerId)
