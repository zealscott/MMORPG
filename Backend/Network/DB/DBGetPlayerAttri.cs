using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public void GetPlayerAttri(int playerid, Player player)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GetPlayerAttriSQL, conn);
                objCommand.Parameters.Add("@playerid", NpgsqlTypes.NpgsqlDbType.Integer).Value = playerid;
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();
                
                reader.Read();
                // read attribution of the player
                player.user = reader.GetString(reader.GetOrdinal("name")).Trim();
                player.speed = reader.GetInt32(reader.GetOrdinal("speedvalue"));
                player.level = reader.GetInt32(reader.GetOrdinal("levelValue"));
                player.currentHP = reader.GetInt32(reader.GetOrdinal("HPValue"));
                player.attack = reader.GetInt32(reader.GetOrdinal("AttackValue"));
                player.defense = reader.GetInt32(reader.GetOrdinal("DefenseValue"));
                player.intelligence = reader.GetInt32(reader.GetOrdinal("intelligencevalue"));
                player.GoldNum = reader.GetInt32(reader.GetOrdinal("goldnum"));
                player.SilverNum = reader.GetInt32(reader.GetOrdinal("silvernum"));
            }
        }
    }
}
