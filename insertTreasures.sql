-- treasures
-- Amulet_1
INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Amulet_1', 5, 1, 1, 1, 6);

-- Amulet_2
INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Amulet_2', 5, 1, 2, 1, 7);


-- Mall
INSERT INTO 
mall(treasureid, name, price)
VALUES(1, 'Amulet_1', 18);

INSERT INTO 
mall(treasureid, name, price)
VALUES(2, 'Amulet_2', 26);


-- treasurecollection
INSERT INTO 
treasurecollection(playerid, treasureid, name, wear, ownnum, sell, sellnum)
VALUES(1, 1, 'Amulet_1', false, 1, 30, 1);

INSERT INTO 
treasurecollection(playerid, treasureid, name, wear, ownnum, sell, sellnum)
VALUES(1, 2, 'Amulet_2', false, 1, 40, 1);
