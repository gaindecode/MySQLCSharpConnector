using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Windows.Forms;

namespace SqlConnection
{
    class Program
    {
        MySqlConnection conn = null;
        MySqlDataReader rdr = null;
        static string cs = @"Server=195.154.9.210;Port=3306;Database=mastertrip;Uid=chevallier;Pwd=motdepasspasdutoutsecurise;";
        [STAThread]
        static void Main(/*string[] args*/)//suppression des arguments car nouveau programa avec interface graphique
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           

           // string cs = @"Server=195.154.9.210;Port=3306;Database=mastertrip;Uid=chevallier;Pwd=motdepasspasdutoutsecurise;";

            
            Thread.Sleep(20000);
        }

        static void openConnection() {
                       
        }
    }
}


