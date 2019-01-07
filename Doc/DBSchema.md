#### 数据库物理设计

- **玩家表** Player

| PlayerID           | Name              | Passwd            | GoldNum                     | SilverNum                   | LevelValue                               | SpeedValue         | IntelligenceValue  | AttackValue        | DefenseValue       | HPValue           | Last_Login | Last_find_treasure | Online  |
| ------------------ | ----------------- | ----------------- | --------------------------- | --------------------------- | ---------------------------------------- | ------------------ | ------------------ | ------------------ | ------------------ | ----------------- | ---------- | ------------------ | ------- |
| serial primary key | char(20) not null | char(20) not null | integer not null default 20 | integer not null default 20 | smallint CHECK(LevelValue > 0) default 1 | integer default 10 | integer default 10 | integer default 10 | integer default 10 | integer default 5 | TIMESTAMP  | TIMESTAMP          | boolean |

- **宝物表 **Treasures

| TreasureID         | Name                     | MainType | SpeedValue | IntelligenceValue | AttackValue | DefenseValue |
| ------------------ | ------------------------ | -------- | ---------- | ----------------- | ----------- | ------------ |
| serial PRIMARY KEY | char(20) not null UNIQUE | integer  | integer    | integer           | integer     | integer      |



- **玩家拥有宝物关系表** Package

| PlayerName | TreasureName | Wear     | OwnNum |
| ---------- | ------------ | -------- | ------ |
| char(20)   | char(20)     | boolean default false | integer default 1 |



- **交易市场出售宝物表** Mall

| TreasureName | Price            | OwnerName               | IsGold                |
| ------------ | ---------------- | ----------------------- | --------------------- |
| char(20)     | integer not null | char(20) default 'mall' | boolean default false |



- **交易记录表** Trade

| TradeID            | ItemName | SellerName | BuyerName | IsGold  | Num                              | Price                     | TradeTime          |
| ------------------ | -------- | ---------- | --------- | ------- | -------------------------------- | ------------------------- | ------------------ |
| serial PRIMARY KEY | char(20) | char(20)   | char(20)  | boolean | integer CHECK(Num > 0) default 1 | integer CHECK(Price >= 0) | TIMESTAMP not null |



- **聊天记录表**

| FromWho           | ToWho             | Content | chatTime           |
| ----------------- | ----------------- | ------- | ------------------ |
| char(20) not null | char(20) not null | text    | TIMESTAMP not null |

- **好友关系表** Friends

| PlayerName1 | PlayerName2 |
| ----------- | ----------- |
| char(20)    | char(20)    |

PS:：PRIMARY KEY(PlayerName1, PlayerName2)


- **好友请求表** FriendRequest

| FromName | ToName   |
| -------- | -------- |
| char(20) | char(20) |

PS：PRIMARY KEY(FromName, ToName)

- **数据库类型与NpgsqlDbType**

```
Postgresql  NpgsqlDbType System.DbType Enum .Net System Type
----------  ------------ ------------------ ----------------
int8        Bigint       Int64              Int64
bool        Boolean      Boolean            Boolean
bytea       Bytea        Binary             Byte[]
date        Date         Date               DateTime
float8      Double       Double             Double
int4        Integer      Int32              Int32
money       Money        Decimal            Decimal
numeric     Numeric      Decimal            Decimal
float4      Real         Single             Single
int2        Smallint     Int16              Int16
text        Text         String             String
time        Time         Time               DateTime
timetz      Time         Time               DateTime
timestamp   Timestamp    DateTime           DateTime
timestamptz TimestampTZ  DateTime           DateTime
interval    Interval     Object             TimeSpan
varchar     Varchar      String             String
inet        Inet         Object             IPAddress
bit         Bit          Boolean            Boolean
uuid        Uuid         Guid               Guid
array       Array        Object             Array
```