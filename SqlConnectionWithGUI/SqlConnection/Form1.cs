using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlConnection;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace SqlConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        String Name = "";
        String Address = "";
        String MonText = "";

        private void button2_Click(object sender, EventArgs e)
        {
            
                MySqlConnection conn = null;
                MySqlDataReader rdr = null;
                try
                {
                    string cs = @"Server=195.154.9.210;Port=3306;Database=mastertrip;Uid=chevallier;Pwd=motdepasspasdutoutsecurise;";
                    conn = new MySqlConnection(cs);
                    conn.Open();
                    //  Console.WriteLine("MySQL version : {0}", conn.ServerVersion);
                    //new openConnection();
                    string stm = "SELECT name,address FROM sites";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    rdr = cmd.ExecuteReader();
                    Console.WriteLine("Name\tAddresse");
                    while (rdr.Read())
                    {
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine(rdr.GetString(0) + "\t" + rdr.GetString(1));

                    }
                    MonText = rdr.GetString(0) + "--" + "\t" + rdr.GetString(1);
                    label3.Text = MonText;

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
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            if (Name != "" && Address != "")
            {
                try
                {
                    string cs = @"Server=195.154.9.210;Port=3306;Database=mastertrip;Uid=chevallier;Pwd=motdepasspasdutoutsecurise;";
                    conn = new MySqlConnection(cs);
                    conn.Open();

                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO sites(name,Address) VALUES(?name,?Address)";
                    cmd.Parameters.AddWithValue("?name", Name);
                    cmd.Parameters.AddWithValue("?Address", Address);
                    cmd.ExecuteNonQuery();



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
            }
            else
            {
                Console.WriteLine("Remplissez");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            Name = t.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox t2 = (TextBox)sender;
            Address = t2.Text;
        }

      

        private void label3_Click(object sender, EventArgs e)
        {
            Label label3 = (Label)sender;
            label3.Text = MonText;

        }
    }
}
