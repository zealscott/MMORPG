using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;
using System.Collections.Generic;
using Common;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public Dictionary<string, DTreasureOwnership> GetGoldenT()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GetGoldenTreasureSQL, conn);
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();
                Dictionary<string, DTreasureOwnership> result = new Dictionary<string, DTreasureOwnership>();

                while (reader.Read())
                {
                    // read attributes of all the treasures
                    DTreasureOwnership tmp = new DTreasureOwnership()
                    {
                        ownerId = reader.GetInt32(reader.GetOrdinal("playerid")),
                        treasureId = reader.GetInt32(reader.GetOrdinal("treasureid")),
                        wear = reader.GetBoolean(reader.GetOrdinal("wear")),
                        price = reader.GetInt32(reader.GetOrdinal("sell")),
                        sellNum = reader.GetInt32(reader.GetOrdinal("sellnum")),
                        number = reader.GetInt32(reader.GetOrdinal("ownnum"))
                    };
                    result.Add(reader.GetString(reader.GetOrdinal("name")).Trim(), tmp);
                };
                return result;
            }
        }
    }
}
