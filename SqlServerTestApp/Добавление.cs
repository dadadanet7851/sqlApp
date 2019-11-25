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
    public partial class Добавление : Form
    {
        public Добавление()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AddAgentButton_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<ДобавлениеАгента>();
        }

        private void AddVButton_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<ДобавлениеВакансии>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<DBConnectionForm>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select top 3 Должность, [Заработная плата] from Вакансия order by [Заработная плата] DESC"
                ;
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Должность", "Должность");
            dataGridView1.Columns.Add("Заработная плата", "Заработная плата"); 
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0], row[1]);
            }
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "select Фамилия, [Год рождения] from Соискатель where";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Год рождения", "Год рождения");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0], row[1]);
            }
            dataGridView1.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<ДобавлениеРаботодателя>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<ПросмотрТаблиц>();
        }
    }
}
