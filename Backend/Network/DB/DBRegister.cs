using System;
using Npgsql;
using Common;

namespace Backend.Network
{
    public partial class ConnectDB
    {
        public int registerUser(String name,String passwd)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            int rowsAffected = 0;
            try
            {
                conn.Open();
                NpgsqlCommand objCommand = new NpgsqlCommand(registerSQL, conn);

                objCommand.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Char).Value = name;
                objCommand.Parameters.Add("@passwd", NpgsqlTypes.NpgsqlDbType.Char).Value = passwd;

                // whether command is successfully executed
                rowsAffected = objCommand.ExecuteNonQuery();
                return rowsAffected;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return rowsAffected;
            }
            finally
            {
                conn.Close(); 
            }
        }
    }
}
