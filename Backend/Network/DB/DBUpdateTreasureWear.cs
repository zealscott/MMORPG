using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int UpdateTreasureWear(string playername, string treasurename, bool wear)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(UpdateTreasureWearSQL, conn);
                objCommand.Parameters.Add("@playername", NpgsqlTypes.NpgsqlDbType.Char).Value = playername;
                objCommand.Parameters.Add("@treasurename", NpgsqlTypes.NpgsqlDbType.Char).Value = treasurename;
                objCommand.Parameters.Add("@wear", NpgsqlTypes.NpgsqlDbType.Boolean).Value = wear;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
