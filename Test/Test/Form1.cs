using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Test
{
    public partial class Form1 : Form
    {
        MySqlConnection con = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        string connectionString = "server=127.0.0.1;user id=sajeruk;password=whosyourdaddy;database=User";

        public Form1()
        {
            InitializeComponent();

            new Form2().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new MySqlConnection(connectionString);

            con.Open();

            command = new MySqlCommand("select name from user join role on user.Idrole = role.idrole where Login = @LOGIN and Password = @PASSWORD", con);
            command.Parameters.AddWithValue("@LOGIN", textBox1.Text);
            command.Parameters.AddWithValue("@PASSWORD", textBox2.Text);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    MessageBox.Show(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("оТСУТСВУЕТ ПОЛЬЗОВАТЕЛЬ.");
            }

            reader.Close();
            con.Close();
        }
    }

}
