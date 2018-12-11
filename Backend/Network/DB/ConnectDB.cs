using System;


namespace Backend.Network
{
    public partial class ConnectDB
    {
        string connStr = "Server=219.228.148.128; Port=5432; Username=postgres; Password=postgres; Database=mmorpg";
        string registerSQL = "INSERT INTO player (name,passwd) VALUES (@name,@passwd)";
        string logInSQL = "SELECT playerid FROM player WHERE name = @name AND passwd = @passwd";
        string GetPlayerAttriSQL = "SELECT * FROM player WHERE playerid = @playerid";
    }
}
