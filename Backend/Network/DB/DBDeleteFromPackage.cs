using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int DBDeleteFromPackage(string playername, string treasurename)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(DeleteFromPackageSQL, conn);
                objCommand.Parameters.Add("@playername", NpgsqlTypes.NpgsqlDbType.Char).Value = playername;
                objCommand.Parameters.Add("@treasurename", NpgsqlTypes.NpgsqlDbType.Char).Value = treasurename;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
