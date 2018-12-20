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
        public Dictionary<string, DTreasurePackage> DBGetPackage(string playerName)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GetPackageSQL, conn);
                objCommand.Parameters.Add("@playername", NpgsqlTypes.NpgsqlDbType.Char).Value = playerName;
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();
                Dictionary<string, DTreasurePackage> result = new Dictionary<string, DTreasurePackage>();

                while (reader.Read())
                {
                    DTreasurePackage tmp = new DTreasurePackage()
                    {
                        wear = reader.GetBoolean(reader.GetOrdinal("wear")),
                        number = reader.GetInt32(reader.GetOrdinal("ownnum"))
                    };
                    result.Add(reader.GetString(reader.GetOrdinal("treasurename")).Trim(), tmp);
                };

                return result;
            }
        }
    }
}
