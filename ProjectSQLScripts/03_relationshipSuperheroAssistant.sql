USE SuperheroesDb

/*Add SuperheroId to the assistant as a foreign key, this allows the assistants to be assigned to a hero.
One hero can have many assistants, but the assistants can only have one hero*/
ALTER TABLE Assistant 
	ADD SuperheroId int FOREIGN KEY REFERENCES Superhero(HeroId)
