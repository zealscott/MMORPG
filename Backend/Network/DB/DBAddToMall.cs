using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int DBAddToMall(string treasurename, string ownername, bool isgold, int price)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(AddToMallSQL, conn);
                objCommand.Parameters.Add("@treasurename", NpgsqlTypes.NpgsqlDbType.Char).Value = treasurename;
                objCommand.Parameters.Add("@ownername", NpgsqlTypes.NpgsqlDbType.Char).Value = ownername;
                objCommand.Parameters.Add("@isgold", NpgsqlTypes.NpgsqlDbType.Boolean).Value = isgold;
                objCommand.Parameters.Add("@price", NpgsqlTypes.NpgsqlDbType.Integer).Value = price;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
