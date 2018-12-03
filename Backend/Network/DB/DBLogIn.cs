using System;
using Npgsql;
using System.Data.Common;
using Backend.Game;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int LogIn(String name, String passwd,ref Player play)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            DbDataReader reader = null;
            try
            {
                conn.Open();
                NpgsqlCommand objCommand = new NpgsqlCommand(logInSQL, conn);
                objCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Char).Value = name;
                objCommand.Parameters.Add("@passwd", NpgsqlTypes.NpgsqlDbType.Char).Value = passwd;

                reader = objCommand.ExecuteReader();

                if (!reader.HasRows)
                    return 0;

                else
                {
                    // TODO: get attribute from database
                }
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
