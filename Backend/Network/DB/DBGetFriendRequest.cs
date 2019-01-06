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
        public List<string> GetFriendRequest(string name)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            List<string> results = new List<string>();

            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(FindRequestsSQL, conn);
                objCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Char).Value = name;
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();

                while (reader.Read())
                {
                    string friend = reader.GetString(reader.GetOrdinal("fromname")).Trim(); 
                    results.Add(friend);
                };

                return results;
            }
        }
    }
}
