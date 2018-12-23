using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int UpdatePlayerAttribute(string name, int speedvalue, int intelligencevalue, int attackvalue, int defensevalue)
        {
            int rowsAffected = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(UpdateAttributeSQL, conn);
                objCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Char).Value = name;
                objCommand.Parameters.Add("@speedvalue", NpgsqlTypes.NpgsqlDbType.Integer).Value = speedvalue;
                objCommand.Parameters.Add("@intelligencevalue", NpgsqlTypes.NpgsqlDbType.Integer).Value = intelligencevalue;
                objCommand.Parameters.Add("@attackvalue", NpgsqlTypes.NpgsqlDbType.Integer).Value = attackvalue;
                objCommand.Parameters.Add("@defensevalue", NpgsqlTypes.NpgsqlDbType.Integer).Value = defensevalue;
                conn.Open();

                rowsAffected = objCommand.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
