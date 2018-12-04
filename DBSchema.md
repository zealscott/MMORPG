### 数据库操作

#### 数据库物理设计

- **玩家表**

| PlayerID | Name     | Passwd   | Coin    | LevelValue | SpeedValue | IntelligenceValue | AttackValue | DefenseValue | HPValue | Last_Login | Last_find_treasure | Online  |
| -------- | -------- | -------- | ------- | ---------- | ---------- | ----------------- | ----------- | ------------ | ------- | ---------- | ------------------ | ------- |
| serial   | char(20) | char(30) | integer | smallint   | integer    | integer           | integer     | integer      | integer | TIMESTAMP  | TIMESTAMP          | boolean |

- **宝物表**

| TreasureID | Name     | AttributeValue | Type   |
| ---------- | -------- | -------------- | ------ |
| serial     | char(20) | integer        | t_type |

其中 `t_type` 为 `ENUM` ('speed', 'intelligence', 'attack', 'defence').

- **玩家拥有宝物关系表**

| PlayerID | TreasureID | Name     | Type   | AttributeValue | Wear    |
| -------- | ---------- | -------- | ------ | -------------- | ------- |
| integer  | integer    | char(20) | t_type | integer        | boolean |

其中 `t_type` 为 `ENUM` ('speed', 'intelligence', 'attack', 'defence').

- **交易市场出售宝物表**

| ItemID  | SellerID | Name     | Type   | AttributeValue | Price   |
| ------- | -------- | -------- | ------ | -------------- | ------- |
| integer | integer  | char(20) | t_type | integer        | integer |

其中 `t_type` 为 `ENUM` ('speed', 'intelligence', 'attack', 'defence').

- **决斗记录表**

| BattleID | WinnerID | LoserID | FightTime |
| -------- | -------- | ------- | --------- |
| serial   | integer  | integer | TIMESTAMP |

- **交易记录表**

| TradeID | ItemID  | SellerID | BuyerID | Price   | TradeTime |
| ------- | ------- | -------- | ------- | ------- | --------- |
| serial  | integer | integer  | integer | integer | TIMESTAMP |

## 数据库类型与NpgsqlDbType

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