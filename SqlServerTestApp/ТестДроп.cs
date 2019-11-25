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
    public partial class ТестДроп : Form
    {
        public ТестДроп()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ТестДроп_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string np = null;
            int? vd = null;
            string a = null;
            string t = null;
            try
            {
                np = textBox1.Text;
                vd = Convert.ToInt32((comboBox1.SelectedItem as IdentityItem)?.Id);
                a = textBox2.Text;
                t = textBox3.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into Работодатели ([Название предприятия], [id деятельности], Адрес, Телефон)" +
                "values (" + $"'{np}','{vd}','{a}','{t}'" + ")";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string da = "select * from [Работодатели]";
            var list = DBConnectionService.SendQueryToSqlServer(da);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id работодателя", "id работодателя");
            dataGridView1.Columns.Add("Название предприятия", "Название предприятия");
            dataGridView1.Columns.Add("id деятельности", "id деятельности");
            dataGridView1.Columns.Add("Адрес", "Адрес");
            dataGridView1.Columns.Add("Телефон", "Телефон");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
            }
            dataGridView1.Refresh();
        }
        public class IdentityItem
        {
            public string Id { get; set; }
            public string Name { get; set; }

            public IdentityItem(string id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string query = "select [id деятельности], [Вид деятельности] from [Виды деятельности]";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(list);
        }

        private void ТестДроп_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CloseForm();
        }
    }
}
