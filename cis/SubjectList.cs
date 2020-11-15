using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace cis
{
    public partial class SubjectList : Form
    {
        DB db;
        MySqlDataAdapter adapter;
        string request = "select * from information";
        DataSet ds;
        MySqlCommandBuilder commandBuilder;
        public SubjectList(DB db, int facNumber, int speciality, string author)
        {
            try
            {
                InitializeComponent();
                this.db = db;
                if (facNumber != 0)
                    request = $"Select * from information where fac = {facNumber} and speciality = {speciality} order by id";
                else
                    request = $"Select * from information where author = '{author}' order by id";
                string connectionString = "server = localhost; username = root; database = cis; password = berest2008";
                this.WindowState = FormWindowState.Maximized;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    adapter = new MySqlDataAdapter(request, connection);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView.DataSource = ds.Tables[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Hide();
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.Remove(row);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            commandBuilder = new MySqlCommandBuilder(adapter);
            adapter.Update(ds);
        }
    }
}