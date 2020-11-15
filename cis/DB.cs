using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cis
{
    public class DB
    {
        public MySqlConnection connection;
        MySqlCommand command;
        Microsoft.Office.Interop.Excel.Application ExcelApp;
        MySqlDataReader reader;
        MySqlDataAdapter adapter;
        DataTable dt;
        MySqlCommandBuilder builder;
        public void UpdateTable(DataGridView dataGridView)
        {
            string command = "Select * From information";
            adapter = new MySqlDataAdapter(command, connection);
            builder = new MySqlCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            adapter.Update((DataTable)dataGridView.DataSource);//обновляет БД
        }
        public DB(string connection)
        {
            this.connection = new MySqlConnection(connection);
            this.connection.Open();          
        }
        public void FillComboBox(ComboBox comboBoxFac, string query)
        {
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBoxFac.Items.Add(reader[0]);
            }
            reader.Close();
        }
        public void FillTable(DataGridView table, int facNumber, int speciality, string author)
        {
            if(facNumber != 0)
                query = $"Select * from information where fac = {facNumber} and speciality = {speciality} order by id";
            else
                query = $"Select * from information where author = '{author}' order by id";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[11]);
                for (int i = 0; i < 11; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }
            }

            reader.Close();
            foreach (string[] str in data)
            {
                table.Rows.Add(str);
            }
        }
        public void DeleteRow(string query)
        {
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        public void InputDB(string query)
        {

            command = new MySqlCommand(query,connection);
            command.ExecuteNonQuery();
        }
        string query;
        public void FillExcel(int facNumber, int specialityNumber, string author)
        {
            ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            if (facNumber != 0)
            {
                query = $"Select * from information where fac = {facNumber} and speciality = {specialityNumber} order by id";
            }
            else
            {
                query = $"Select * from information where author = '{author}' order by id";
            }
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            int i = 1;
            while (reader.Read())
            {
                for (int j = 1; j < 12; j++)
                {
                    ExcelApp.Cells[i, j] = reader[j - 1];
                }
                i++;
            }
            reader.Close();
            ExcelApp.Visible = true;
        }
    }
}