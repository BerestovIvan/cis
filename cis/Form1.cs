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
using Microsoft.Office.Interop.Excel;
using Application = System.Windows.Forms.Application;

namespace cis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
                db = new DB(connection);
                comboBoxFac.Items.Add("Преподавателям");
                comboBoxFac.Items.Add("Специальностям");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string connection = "server=localhost;username=root;database=cis;password=berest2008";
        DB db;
        int choice = 13; // 0 -  fac choice  1 - speciality choice
        int facNumber;
        int specialityNumber;
        string selectedState;
        private void comboBoxFuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState = comboBoxFac.SelectedItem.ToString();
                if (choice == 2)
                {
                    labelFac.Text = "Поиск по";
                    specialityNumber = int.Parse(selectedState.ToString());
                    comboBoxFac.Items.Clear();
                    comboBoxFac.Items.Add("Преподавателям");
                    comboBoxFac.Items.Add("Специальностям");
                    if (radioButtonExcel.Checked)
                    {
                        db.FillExcel(facNumber, specialityNumber, selectedState);
                        this.WindowState = FormWindowState.Minimized;
                    }
                    else
                    {
                        SubjectList subjectList = new SubjectList(db, facNumber, specialityNumber, selectedState);
                        subjectList.Show();
                    }
                    facNumber = 0;
                    specialityNumber = 0;
                }
                if (choice == 1)
                {
                    labelFac.Text = "Выберете специальность";
                    comboBoxFac.Items.Clear();
                    facNumber = int.Parse(selectedState.ToString());
                    db.FillComboBox(comboBoxFac, $"select speciality from information where fac = {facNumber} group by speciality");

                    choice = 2;
                }
                if (choice == 0) //вывод поиска по преподам
                {
                    comboBoxFac.Items.Clear();
                    comboBoxFac.Items.Add("Преподавателям");
                    comboBoxFac.Items.Add("Специальностям");
                    labelFac.Text = "Поиск по";
                    if (radioButtonExcel.Checked)
                    {
                        db.FillExcel(0, 0, selectedState);
                        this.WindowState = FormWindowState.Minimized;
                    }
                    else
                    {
                        SubjectList subjectList = new SubjectList(db, facNumber, specialityNumber, selectedState);
                        subjectList.Show();
                    }
                }
                if (selectedState == "Преподавателям")
                {
                    labelFac.Text = "Выберете автора";
                    comboBoxFac.Items.Clear();                  
                    db.FillComboBox(comboBoxFac, "select author from information group by author");
                    choice = 0; //преподаватель еще не выыбран
                }
                if (selectedState == "Специальностям")
                {
                    labelFac.Text = "Выберете факультет";
                    comboBoxFac.Items.Clear();
                    db.FillComboBox(comboBoxFac, "select fac from faculty");
                    choice = 1; //заполнен факультетами
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверный формат данных");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            db.connection.Close();
            Application.Exit();
        }       
    }
}