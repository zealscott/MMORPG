using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int AddFriend(string playername1, string playername2)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(AddFriendSQL, conn);
                objCommand.Parameters.Add("@playername1", NpgsqlTypes.NpgsqlDbType.Char).Value = playername1;
                objCommand.Parameters.Add("@playername2", NpgsqlTypes.NpgsqlDbType.Char).Value = playername2;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
