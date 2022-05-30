using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form2 : Form
    {
        MySqlConnection con = null;
        MySqlCommand command = null;
        MySqlDataAdapter adapter = null;
        string connectionString = "server=127.0.0.1;user id=sajeruk;password=whosyourdaddy;database=User";

        DataTable dataTable = null;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new MySqlConnection(connectionString);

            con.Open();

            dataTable = new DataTable();

            command = new MySqlCommand("select Login, Password, name from user join role on user.Idrole = role.idrole", con);

            adapter = new MySqlDataAdapter(command);

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable.DefaultView;

            con.Close();

        }
    }
}
