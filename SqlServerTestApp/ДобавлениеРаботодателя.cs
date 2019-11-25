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
    public partial class ДобавлениеРаботодателя : Form
    {
        public ДобавлениеРаботодателя()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string np = null;
            string vd = null;
            string a = null;
            int? t = null;
            try
            {
                np = textBox1.Text;
                vd = textBox2.Text;
                a = textBox3.Text;
                t = Convert.ToInt32(textBox4.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into Работодатель ([Название предприятия], [Вид деятельности], Адрес, Телефон)" +
                "values (" + $"'{np}','{vd}','{a}','{t}'" + ")";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void ДобавлениеРаботодателя_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CloseForm();
        }
    }
}
