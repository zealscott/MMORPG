using System;
using Npgsql;
using System.Collections.Generic;
using System.Text;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public void DBSyncChat(List<String> chatHistory)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            StringBuilder InsertChatSQL = new StringBuilder("INSERT INTO ChatLog (fromwho, towho,content,chattime) VALUES ");
            try
            {
                InsertChatSQL.Append(string.Join(",", chatHistory));
                InsertChatSQL.Append(";");
                conn.Open();
                NpgsqlCommand objCommand = new NpgsqlCommand(InsertChatSQL.ToString(), conn);
                objCommand.CommandType = System.Data.CommandType.Text;
                objCommand.ExecuteNonQuery();
                Console.WriteLine("DBSyncChat");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close(); 
            }
        }
    }
}
