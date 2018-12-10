DROP DATABASE mmorpg;

CREATE DATABASE mmorpg;

\c mmorpg;

CREATE TYPE t_type AS ENUM ('speed', 'intelligence', 'attack', 'defence');

-- 创建玩家表，PlayID根据玩家注册先后进行自动新建，唯一表明该玩家
CREATE TABLE Player 
(
	PlayerID serial PRIMARY KEY,	
	Name char(20) not null UNIQUE,
	Passwd char(30) not null, 
	Coin integer not null default 20,
	LevelValue smallint CHECK(LevelValue > 0) default 1,		-- 等级
	SpeedValue integer default 10,								-- 速度
	IntelligenceValue integer default 10,						-- 智力
	AttackValue integer default 10,								-- 攻击
	DefenseValue integer default 10,							-- 防御
	HPValue integer default 5, 								-- 生命 0-5 的整数数值
	Last_Login TIMESTAMP,
	Last_find_treasure TIMESTAMP,
	Online boolean
);

CREATE INDEX Player_index ON Player (PlayerID);


-- 创建宝物主表
CREATE TABLE Treasures  
(
	TreasureID serial PRIMARY KEY,
    Name char(20) not null UNIQUE,
	AttributeValue integer,
	Type t_type 						-- 分别是速度、智力、攻击、防御
);

CREATE INDEX Treasures_index ON Treasures (TreasureID);



-- 玩家拥有的宝物
CREATE TABLE TreasureCollection 
(
	PlayerID integer,
	TreasureID integer,
    Name char(20),						-- 宝物名称
    Type t_type,						-- 分别是速度、智力、攻击、防御
    AttributeValue integer,
	Wear boolean,   
	PRIMARY KEY(PlayerID, TreasureID),
	FOREIGN KEY(PlayerID) REFERENCES Player(PlayerID),
	FOREIGN KEY(TreasureID) REFERENCES Treasures(TreasureID),
	FOREIGN KEY(Name) REFERENCES Treasures(Name)
);

CREATE INDEX TreasureCollection_index ON TreasureCollection (PlayerID, TreasureID);
CLUSTER TreasureCollection USING TreasureCollection_index;


-- 交易市场
CREATE TABLE Market 
(
	ItemID integer,
	SellerID integer,
	Name char(20),					-- 宝物名称
    Type t_type,					-- 分别是速度、智力、攻击、防御
    AttributeValue integer,
	Price integer CHECK(Price > 0),   
	PRIMARY KEY(ItemID, SellerID),
	FOREIGN KEY(ItemID) REFERENCES Treasures(TreasureID),
	FOREIGN KEY(SellerID) REFERENCES Player(PlayerID)
);

CREATE INDEX Market_index ON Market (ItemID, SellerID);


-- 决斗记录
CREATE TABLE Battle 
(
	BattleID serial PRIMARY KEY, 
	WinnerID integer not null,
	LoserID integer not null,
	FightTime TIMESTAMP not null,
	FOREIGN KEY(WinnerID) REFERENCES Player(PlayerID),
	FOREIGN KEY(LoserID) REFERENCES Player(PlayerID)
);

CREATE INDEX Battle_index ON Battle (BattleID);


-- 交易记录
create table Trade 
(
	TradeID serial PRIMARY KEY,
	ItemID integer,
	SellerID integer,
	BuyerID integer,
	Price integer CHECK(Price > 0),
    TradeTime TIMESTAMP not null,
	FOREIGN KEY(ItemID) REFERENCES Treasures(TreasureID),
	FOREIGN KEY(SellerID) REFERENCES Player(PlayerID),
	FOREIGN KEY(BuyerID) REFERENCES Player(PlayerID)
);

CREATE INDEX Trade_index ON Trade (TradeID);


-- 聊天记录
CREATE TABLE ChatLog 
(
	FromWho char(20) not null, 
	ToWho char(20) not null, 
	Content text,
	chatTime TIMESTAMP not null
);