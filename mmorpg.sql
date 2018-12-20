-- \i E:/MMORPG/mmorpg.sql

DROP DATABASE mmorpg;

CREATE DATABASE mmorpg;

\c mmorpg;

-- 创建玩家表，PlayID根据玩家注册先后进行自动新建，唯一表明该玩家
CREATE TABLE Player 
(
	PlayerID serial PRIMARY KEY,	
	Name char(20) not null UNIQUE,
	Passwd char(20) not null, 
	GoldNum integer not null default 20,						-- 金币
	SilverNum integer not null default 20,						-- 银币
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
    Name char(20) not null UNIQUE,					-- 宝物名称
	MainType integer,								-- 宝物类型：helmet:1\armour:2\leftWeapon:3\rightWeapon:4\shield:5\magicPortion:6
	SpeedValue integer,								-- 速度
	IntelligenceValue integer,						-- 智力
	AttackValue integer,							-- 攻击
	DefenseValue integer							-- 防御
);

CREATE INDEX Treasures_index ON Treasures (TreasureID);



-- 玩家拥有的宝物
CREATE TABLE Package 
(
	PlayerName char(20),
    TreasureName char(20),										-- 宝物名称
	Wear boolean default false,   								-- 是否装备
	OwnNum integer default 1,									-- 该宝物拥有的数量

	PRIMARY KEY(PlayerName, TreasureName),
	FOREIGN KEY(PlayerName) REFERENCES Player(Name),
	FOREIGN KEY(TreasureName) REFERENCES Treasures(Name)
);


-- 商场中无限量供应的宝物
CREATE TABLE Mall
(
	TreasureName char(20),							-- 宝物名称
	Price integer not null, 						-- 宝物价格
	OwnerName char(20) default 'mall',				-- 拥有者
	IsGold boolean default false,					-- 金币/银币购买

	FOREIGN KEY(TreasureName) REFERENCES Treasures(Name)
);


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