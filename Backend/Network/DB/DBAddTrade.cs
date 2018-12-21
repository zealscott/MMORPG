using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int AddTrade(string ItemName, string SellerName, string BuyerName, int number, int price)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(AddTradeSQL, conn);
                objCommand.Parameters.Add("@ItemName", NpgsqlTypes.NpgsqlDbType.Char).Value = ItemName;
                objCommand.Parameters.Add("@SellerName", NpgsqlTypes.NpgsqlDbType.Char).Value = SellerName;
                objCommand.Parameters.Add("@BuyerName", NpgsqlTypes.NpgsqlDbType.Char).Value = BuyerName;
                objCommand.Parameters.Add("@IsGold", NpgsqlTypes.NpgsqlDbType.Boolean).Value = false;
                objCommand.Parameters.Add("@Num", NpgsqlTypes.NpgsqlDbType.Integer).Value = number;
                objCommand.Parameters.Add("@Price", NpgsqlTypes.NpgsqlDbType.Integer).Value = price;
                objCommand.Parameters.Add("@TradeTime", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = System.DateTime.Now;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
