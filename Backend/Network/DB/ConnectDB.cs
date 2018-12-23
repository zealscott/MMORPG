using System;


namespace Backend.Network
{
    public partial class ConnectDB
    {
        string connStr = "Server=219.228.148.128; Port=5432; Username=postgres; Password=postgres; Database=mmorpg";
        string registerSQL = "INSERT INTO player (name,passwd) VALUES (@name,@passwd)";
        string logInSQL = "SELECT playerid FROM player WHERE name = @name AND passwd = @passwd";
        string GetPlayerAttriSQL = "SELECT * FROM player WHERE playerid = @playerid";
        string GetTreasureAttriSQL = "SELECT * FROM treasures";
        string GetMallSQL = "SELECT * FROM mall";
        string GetPackageSQL = "SELECT * FROM package WHERE playername = @playername";
        string UpdateTreasureNumSQL = "UPDATE package SET ownnum = @number WHERE playername = @playername AND treasurename = @treasurename";
        string UpdataSilverNumSQL = "UPDATE player SET silvernum = @silvernum WHERE name = @name";
        string GoldTransactionSQL = "BEGIN; UPDATE player SET goldnum = goldnum + @goldCoin WHERE name = @seller; UPDATE player SET goldnum = goldnum - @goldCoin WHERE name = @buyer; INSERT INTO package(playername, treasurename) VALUES(@buyer, @goods); DELETE FROM mall WHERE TreasureName = @goods; INSERT INTO trade (ItemName,SellerName,BuyerName,IsGold,Price,TradeTime) VALUES (@goods,@seller,@buyer,@IsGold,@goldCoin,@TradeTime); COMMIT ";
        string AddTradeSQL = "INSERT INTO trade (ItemName,SellerName,BuyerName,IsGold,Num,Price,TradeTime) VALUES (@ItemName,@SellerName,@BuyerName,@IsGold,@Num,@Price,@TradeTime)";
        string UpdateAttributeSQL = "UPDATE player SET speedvalue = @speedvalue, intelligencevalue = @intelligencevalue, attackvalue = @attackvalue, defensevalue = @defensevalue WHERE name = @name";
        string UpdateTreasureWearSQL = "UPDATE package SET wear = @wear WHERE playername = @playername AND treasurename = @treasurename";
        string DeleteFromPackageSQL = "Delete FROM package WHERE playername = @playername AND treasurename = @treasurename";
        string AddToMallSQL = "INSERT INTO mall(treasurename, price, ownername, isgold) VALUES (@treasurename, @price, @ownername, @isgold)";
    }
}
