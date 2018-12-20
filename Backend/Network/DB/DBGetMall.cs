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
        public Dictionary<string, DTreasureMall> DBGetMall()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            Dictionary<string, DTreasureMall> result = new Dictionary<string, DTreasureMall>();
            
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GetMallSQL, conn);
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();

                while (reader.Read())
                {
                    DTreasureMall tmp = new DTreasureMall()
                    {
                        ownerName = reader.GetString(reader.GetOrdinal("ownername")).Trim(),
                        price = reader.GetInt32(reader.GetOrdinal("price")),
                        isGold = reader.GetBoolean(reader.GetOrdinal("isgold"))
                    };
                    result.Add(reader.GetString(reader.GetOrdinal("treasurename")).Trim(), tmp);
                };

                return result;
            }
        }
    }
}
