using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;


namespace SqlConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            string cs = @"Server=195.154.9.210;Port=3306;Database=mastertrip;Uid=chevallier;
Pwd=motdepasspasdutoutsecurise;";

            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                Console.WriteLine("MySQL version : {0}", conn.ServerVersion);

                string stm = "SELECT name,address FROM sites";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
                Console.WriteLine("Name\tAddresse");
                while (rdr.Read())
                {
                    Console.WriteLine("*************************************************************************");
                    Console.WriteLine(rdr.GetString(0) + "\t" + rdr.GetString(1));

                }


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Thread.Sleep(20000);
        }
    }
}


