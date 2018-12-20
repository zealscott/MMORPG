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
        string ChangeTreasureNumSQL = "UPDATE package SET ownnum = ownnum + @number WHERE playername = @playername AND treasurename = @treasurename";
        string ChangeSilverNumSQL = "UPDATE player SET silvernum = silvernum - @silvernum WHERE name = @name";
        string GoldTransactionSQL = "BEGIN; UPDATE player SET goldnum = goldnum + @goldCoin WHERE name = @seller; UPDATE player SET goldnum = goldnum - @goldCoin WHERE name = @buyer; INSERT INTO package(playername, treasurename) VALUES(@buyer, @goods); DELETE FROM mall WHERE TreasureName = @goods; COMMIT ";
           
    }
}
