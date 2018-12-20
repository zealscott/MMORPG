using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;
using System.Text;
using System.Collections.Generic;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int BuyNewSilverTreasure(List<string> silverTreasures)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            StringBuilder InsertChatSQL = new StringBuilder("INSERT INTO package (playername, treasurename, ownnum) VALUES ");
            try
            {
                InsertChatSQL.Append(string.Join(",", silverTreasures));
                InsertChatSQL.Append(";");
                conn.Open();
                NpgsqlCommand objCommand = new NpgsqlCommand(InsertChatSQL.ToString(), conn);
                objCommand.CommandType = System.Data.CommandType.Text;
                rowsAffected = objCommand.ExecuteNonQuery();
                Console.WriteLine("DBBuySilverTreasure");
                return rowsAffected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
