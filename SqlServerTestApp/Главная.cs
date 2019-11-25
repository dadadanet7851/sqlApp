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
    public partial class Главная : Form
    {
        public Главная()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<DBConnectionForm>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<ПросмотрТаблиц>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<ТестДроп>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.OpenNewForm<Запросы>();
        }
    }
}
