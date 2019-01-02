using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int RemoveFromMall(string ownername, string treasurename)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(RemoveFromMallSQL, conn);
                objCommand.Parameters.Add("@ownername", NpgsqlTypes.NpgsqlDbType.Char).Value = ownername;
                objCommand.Parameters.Add("@treasurename", NpgsqlTypes.NpgsqlDbType.Char).Value = treasurename;
                conn.Open();
                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
