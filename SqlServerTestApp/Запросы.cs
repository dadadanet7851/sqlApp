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
            string query = "SELECT * FROM (SELECT *, DATEDIFF(MONTH, [Год рождения], GETDATE())/12 as Возраст FROM Соискатели )MyTab WHERE Возраст BETWEEN 18 AND 43 ORDER BY Возраст ASC";
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
            dataGridView1.Columns.Add("Возраст", "Возраст");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9]);
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
            dataGridView1.Columns.Add("Кол-во вакансий у фирмы \"Рога и копыта\"", "Кол-во вакансий у фирмы \"Рога и копыта\"");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0]);
            }
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT (*) FROM Вакансии WHERE ([id должности] = 1) AND (Открытая = 1)";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Кол-во открытых вакансий на должность \"Инженер-программист\"", "Кол-во открытых вакансий на должность \"Инженер-программист\"");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0]);
            }
            dataGridView1.Refresh();
        }
    }
}
