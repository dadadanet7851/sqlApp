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
    public partial class Запросы : Form
    {
        public Запросы()
        {
            InitializeComponent();
        }

        private void Запросы_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CloseForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Соискатели WHERE datediff(yy, [Год рождения], getdate()) between 18 and 43";                           // http://xandeadx.ru/blog/mysql/515
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id соискателя", "id соискателя");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("Год рождения", "Год рождения");
            dataGridView1.Columns.Add("Образование", "Образование");
            dataGridView1.Columns.Add("Должность", "Должность");
            dataGridView1.Columns.Add("Квалификация", "Квалификация");
            dataGridView1.Columns.Add("Предполагаемый размер заработной платы", "Предполагаемый размер заработной платы");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]);
            }
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select top 3 * from [Вакансии] order by [Заработная плата] desc";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id вакансии", "id вакансии");
            dataGridView1.Columns.Add("id работодателя", "id работодателя");
            dataGridView1.Columns.Add("Должность", "Должность");
            dataGridView1.Columns.Add("Требуемый уровень образования", "Требуемый уровень образования");
            dataGridView1.Columns.Add("Квалификация", "Квалификация");
            dataGridView1.Columns.Add("Заработная плата", "Заработная плата");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
            }
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT (*) FROM Вакансии WHERE [id работодателя] = 2002";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Кол-во вакансий", "Кол-во вакансий");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0]);
            }
            dataGridView1.Refresh();
        }
    }
}
