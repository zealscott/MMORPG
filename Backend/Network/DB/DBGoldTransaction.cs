using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int GoldTransaction(string buyer, string seller, int goldCoin, string goods)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(GoldTransactionSQL, conn);
                objCommand.Parameters.Add("@goldCoin", NpgsqlTypes.NpgsqlDbType.Integer).Value = goldCoin;
                objCommand.Parameters.Add("@goods", NpgsqlTypes.NpgsqlDbType.Char).Value = goods;
                objCommand.Parameters.Add("@seller", NpgsqlTypes.NpgsqlDbType.Char).Value = seller;
                objCommand.Parameters.Add("@buyer", NpgsqlTypes.NpgsqlDbType.Char).Value = buyer;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
