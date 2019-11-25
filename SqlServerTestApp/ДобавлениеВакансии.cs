using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlServerTestApp
{
    public partial class ДобавлениеВакансии : Form
    {

        public ДобавлениеВакансии()
        {
            InitializeComponent();
        }

        private void ДобавлениеВакансии_Load(object sender, EventArgs e)
        {

        }
        private void AddButton_Click_1(object sender, EventArgs e)
        {
            string np = null;
            string vd = null;
            string d = null;
            string tuo = null;
            string k = null;
            int? zp = null;
            try
            {
                np = NPBox.Text;
                vd = textBox1.Text;
                d = textBox2.Text;
                tuo = textBox3.Text;
                k = textBox4.Text;
                zp = Convert.ToInt32(textBox5.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into Вакансия ([Название предприятия], [Вид деятельности], Должность, [Требуемый уровень образования], Квалификация, [Заработная плата])" +
                "values (" + $"'{np}','{vd}','{d}','{tuo}','{k}','{zp}'" + ")";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<ДобавлениеРаботодателя>();
        }

        private void NPBox_DropDown(object sender, EventArgs e)
        {
            string query = "select [Название предприятия] from Работодатель";
            string[] list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => row[0]).ToArray();
            NPBox.Items.Clear();
            NPBox.Items.AddRange(list);
        }
        private void NPBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ДобавлениеВакансии_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CloseForm();
        }
    }
}
