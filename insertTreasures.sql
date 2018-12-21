-- \i E:/MMORPG/insertTreasures.sql
-- 宝物类型：helmet:1\armour:2\accessory:3\weapon:4\shield:5\elixir:6
-- treasures
INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Amulet_1', 5, 1, 1, 1, 6);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Amulet_2', 5, 1, 2, 1, 7);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Armor_1', 2, 1, 2, 3, 10);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Armor_2', 2, 1, 3, 1, 11);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Armor_3', 2, 3, 2, 1, 9);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Ax_1', 4, 1, 2, 8, 5);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Ax_2', 4, 3, 2, 7, 7);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Ax_3', 4, 1, 1, 9, 7);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Bow', 4, 3, 3, 10, 2);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Elixir_1', 6, 8, 6, 1, 3);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Elixir_2', 6, 10, 5, 2, 1);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Elixir_3', 6, 7, 7, 3, 3);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Elixir_4', 6, 6, 9, 3, 1);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Elixir_5', 6, 4, 5, 4, 5);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Elixir_6', 6, 6, 5, 3, 6);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Flail', 4, 3, 2, 12, 3);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Helmet_1', 1, 2, 6, 1, 6);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Helmet_2', 1, 3, 5, 1, 7);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Helmet_3', 1, 1, 1, 1, 10);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Helmet_4', 1, 2, 2, 2, 8);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Ring_1', 3, 5, 5, 3, 3);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Ring_2', 3, 1, 8, 5, 4);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Shield', 5, 1, 2, 2, 7);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Shurikens', 4, 10, 2, 6, 1);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Stone_1', 3, 6, 2, 3, 6);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Stone_2', 3, 7, 3, 2, 5);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Sword_1', 4, 1, 2, 7, 6);

INSERT INTO 
treasures(name, MainType, speedvalue, intelligencevalue, attackvalue, defensevalue)
VALUES('Sword_2', 4, 2, 2, 6, 7);



-- Mall
INSERT INTO 
mall(TreasureName, price)
VALUES('Amulet_1', 9);

INSERT INTO 
mall(TreasureName, price)
VALUES('Amulet_2', 10);

INSERT INTO 
mall(TreasureName, price, OwnerName, IsGold)
VALUES('Armor_1', 30, 'test', true);

INSERT INTO 
mall(TreasureName, price, OwnerName, IsGold)
VALUES('Armor_2', 35, '123', true);

INSERT INTO 
mall(TreasureName, price, OwnerName, IsGold)
VALUES('Armor_3', 27, 'test', true);

INSERT INTO 
mall(TreasureName, price)
VALUES('Ax_2', 33);

INSERT INTO 
mall(TreasureName, price)
VALUES('Elixir_1', 18);

INSERT INTO 
mall(TreasureName, price)
VALUES('Elixir_2', 26);

INSERT INTO 
mall(TreasureName, price)
VALUES('Elixir_3', 20);

INSERT INTO 
mall(TreasureName, price)
VALUES('Elixir_4', 16);

INSERT INTO 
mall(TreasureName, price)
VALUES('Elixir_5', 22);

INSERT INTO 
mall(TreasureName, price)
VALUES('Elixir_6', 17);

INSERT INTO 
mall(TreasureName, price)
VALUES('Flail', 17);

INSERT INTO 
mall(TreasureName, price)
VALUES('Helmet_1', 17);

INSERT INTO 
mall(TreasureName, price)
VALUES('Helmet_2', 6);

INSERT INTO 
mall(TreasureName, price)
VALUES('Helmet_3', 9);

INSERT INTO 
mall(TreasureName, price)
VALUES('Helmet_4', 23);

INSERT INTO 
mall(TreasureName, price)
VALUES('Ring_1', 10);

INSERT INTO 
mall(TreasureName, price)
VALUES('Ring_2', 35);

INSERT INTO 
mall(TreasureName, price)
VALUES('Shield', 27);

INSERT INTO 
mall(TreasureName, price)
VALUES('Shurikens', 15);

INSERT INTO 
mall(TreasureName, price)
VALUES('Stone_1', 9);

INSERT INTO 
mall(TreasureName, price)
VALUES('Stone_2', 8);

INSERT INTO 
mall(TreasureName, price)
VALUES('Sword_1', 23);

INSERT INTO 
mall(TreasureName, price)
VALUES('Sword_2', 27);


-- package
INSERT INTO 
package(playername, treasurename, wear, ownnum)
VALUES('123', 'Ax_1', false, 1);

INSERT INTO 
package(playername, treasurename, wear, ownnum)
VALUES('test', 'Ax_3', false, 1);

INSERT INTO 
package(playername, treasurename, wear, ownnum)
VALUES('test', 'Bow', false, 1);


-- test transaction
BEGIN;
UPDATE player SET goldnum = goldnum + 10
    WHERE name = '123';
UPDATE player SET goldnum = goldnum - 10
    WHERE name = 'test';
INSERT INTO 
    package(playername, treasurename)
    VALUES('123', 'Armor_2');
DELETE FROM mall
    WHERE TreasureName = 'Armor_2';
COMMIT;