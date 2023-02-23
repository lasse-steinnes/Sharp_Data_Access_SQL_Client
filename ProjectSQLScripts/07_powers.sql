USE SuperheroesDb

INSERT INTO [Power]
([Power-Name], [Description])
VALUES('Feeding time', 'The hero shoots out soup from his hands')

INSERT INTO [Power]
([Power-Name], [Description])
VALUES('Hardest Punch', 'The hero punches really hard')

INSERT INTO [Power]
([Power-Name], [Description])
VALUES('Sppedy Escape', 'The hero Can quickly get out of sticky situations')

INSERT INTO [Power]
([Power-Name], [Description])
VALUES('Sympathy', 'The hero gathers sympathy in any way possible')

INSERT INTO SuperheroPowers
(SuperHeroId,SuperPowerId)
VALUES (1,1)

INSERT INTO SuperheroPowers
(SuperHeroId,SuperPowerId)
VALUES (1,3)

INSERT INTO SuperheroPowers
(SuperHeroId,SuperPowerId)
VALUES (1,4)

INSERT INTO SuperheroPowers
(SuperHeroId,SuperPowerId)
VALUES (2,4)

INSERT INTO SuperheroPowers
(SuperHeroId,SuperPowerId)
VALUES (3,2)

INSERT INTO SuperheroPowers
(SuperHeroId,SuperPowerId)
VALUES (3,4)
