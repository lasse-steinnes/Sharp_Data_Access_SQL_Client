USE SuperheroesDb
/*Inserting Powers into columns*/
INSERT INTO [Power]
([Name], [Description])
VALUES('Feeding Time', 'The hero shoots out soup from his hands')

INSERT INTO [Power]
([Name], [Description])
VALUES('Hardest Punch', 'The hero punches really hard')

INSERT INTO [Power]
([Name], [Description])
VALUES('Speedy Escape', 'The hero can quickly get out of sticky situations')

INSERT INTO [Power]
([Name], [Description])
VALUES('Sympathy', 'The hero gathers sympathy in any way possible')
/*Inserting SuperheroId and SuperPowerId, creating a link between both tables*/
INSERT INTO SuperheroPower
(SuperheroId,SuperPowerId)
VALUES (1,1)

INSERT INTO SuperheroPower
(SuperheroId,SuperPowerId)
VALUES (1,3)

INSERT INTO SuperheroPower
(SuperheroId,SuperPowerId)
VALUES (1,4)

INSERT INTO SuperheroPower
(SuperheroId,SuperPowerId)
VALUES (2,4)

INSERT INTO SuperheroPower
(SuperheroId,SuperPowerId)
VALUES (3,2)

INSERT INTO SuperheroPower
(SuperheroId,SuperPowerId)
VALUES (3,4)
