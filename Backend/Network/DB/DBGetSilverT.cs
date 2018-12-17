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
        public Dictionary<string, int> GetSilverT()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GetSilverTreasureSQL, conn);
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();
                Dictionary<string, int> result = new Dictionary<string, int>();

                while (reader.Read())
                {
                    // read all the silver treasures
                    result.Add(reader.GetString(reader.GetOrdinal("name")).Trim(), reader.GetInt32(reader.GetOrdinal("price")));
                };

                return result;
            }
        }
    }
}
