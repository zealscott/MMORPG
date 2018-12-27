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
        public List<KeyValuePair<string, string>> GetChatHistory(string sender, string receiver, int ChatLogMax)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            List<KeyValuePair<string, string>> results = new List<KeyValuePair<string, string>>();

            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GetChatHistorySQL, conn);
                objCommand.Parameters.Add("@sender", NpgsqlTypes.NpgsqlDbType.Char).Value = sender;
                objCommand.Parameters.Add("@receiver", NpgsqlTypes.NpgsqlDbType.Char).Value = receiver;
                objCommand.Parameters.Add("@maxNum", NpgsqlTypes.NpgsqlDbType.Integer).Value = ChatLogMax;
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();

                while (reader.Read())
                {
                    string senderName;
                    string content;
                    senderName = reader.GetString(reader.GetOrdinal("fromwho")).Trim();
                    content = reader.GetString(reader.GetOrdinal("content")).Trim();
                    results.Add(new KeyValuePair<string, string>(senderName, content));
                };

                return results;
            }
        }
    }
}
