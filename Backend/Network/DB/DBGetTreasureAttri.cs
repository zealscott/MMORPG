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
        public Dictionary<string, DTreasure> GetTreasureAttri()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GetTreasureAttriSQL, conn);
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();
                Dictionary<string, DTreasure> result = new Dictionary<string, DTreasure>();

                while (reader.Read())
                {
                    // read attributes of all the treasures
                    DTreasure tmp = new DTreasure()
                    {
                        treasureId = reader.GetInt32(reader.GetOrdinal("treasureid")),
                        mainType = reader.GetInt32(reader.GetOrdinal("maintype")),
                        speed = reader.GetInt32(reader.GetOrdinal("speedvalue")),
                        intelligence = reader.GetInt32(reader.GetOrdinal("intelligencevalue")),
                        attack = reader.GetInt32(reader.GetOrdinal("attackvalue")),
                        defense = reader.GetInt32(reader.GetOrdinal("defensevalue"))
                    };
                    result.Add(reader.GetString(reader.GetOrdinal("name")).Trim(), tmp);
                };
                return result;
            }
        }
    }
}
