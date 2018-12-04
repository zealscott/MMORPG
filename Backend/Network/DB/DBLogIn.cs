using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int LogIn(String name, String passwd)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            using (conn)
            {
                NpgsqlCommand objCommand = new NpgsqlCommand(logInSQL, conn);
                objCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Char).Value = name;
                objCommand.Parameters.Add("@passwd", NpgsqlTypes.NpgsqlDbType.Char).Value = passwd;
                conn.Open();

                DbDataReader reader = objCommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                    return reader.GetInt32(0);
                else
                    return 0;
            }
        }
    }
}
