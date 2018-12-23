using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int UpdateTreasureNum(string playername, string treasurename, int number)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(UpdateTreasureNumSQL, conn);
                objCommand.Parameters.Add("@number", NpgsqlTypes.NpgsqlDbType.Integer).Value = number;
                objCommand.Parameters.Add("@playername", NpgsqlTypes.NpgsqlDbType.Char).Value = playername;
                objCommand.Parameters.Add("@treasurename", NpgsqlTypes.NpgsqlDbType.Char).Value = treasurename;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
