using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int UpdateSilverNum(string playername, int silvernum)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(UpdataSilverNumSQL, conn);
                objCommand.Parameters.Add("@silvernum", NpgsqlTypes.NpgsqlDbType.Integer).Value = silvernum;
                objCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Char).Value = playername;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
