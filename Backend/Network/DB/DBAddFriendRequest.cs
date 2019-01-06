using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int AddFriendRequest(string fromname, string toname)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(AddFriendRequestSQL, conn);
                objCommand.Parameters.Add("@fromname", NpgsqlTypes.NpgsqlDbType.Char).Value = fromname;
                objCommand.Parameters.Add("@toname", NpgsqlTypes.NpgsqlDbType.Char).Value = toname;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
