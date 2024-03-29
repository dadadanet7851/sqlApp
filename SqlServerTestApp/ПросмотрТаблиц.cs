﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SqlServerTestApp
{
    public partial class ПросмотрТаблиц : Form
    {

        bool tip1;
        bool tip2;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tip1 = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tip1 = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tip2 = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            tip2 = false;
        }

        public ПросмотрТаблиц()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                    // Выделение всей строки при клике на нее
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ПросмотрТаблиц_Shown(object sender, EventArgs e)                                                 // Показ таблицы при загрузке формы
        {
            showButton1.PerformClick();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)                                     // Показ таблиц при выборе вкладки
        {
            if (tabControl1.SelectedIndex == 0)
            {
                showButton1.PerformClick();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                showButton2.PerformClick();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                showButton3.PerformClick();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                showButton4.PerformClick();
            }
            if (tabControl1.SelectedIndex == 4)
            {
                showButton5.PerformClick();
            }
            if (tabControl1.SelectedIndex == 5)
            {
                showButton6.PerformClick();
            }
            if (tabControl1.SelectedIndex == 6)
            {
                showButton7.PerformClick();
            }
        }

        private void ПросмотрТаблиц_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CloseForm();
        }

        private void showButton1_Click(object sender, EventArgs e)                                                    // Обновление таблиц
        {
            string query = "select * from [Агенты бюро]";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id агента", "id агента");
            dataGridView1.Columns.Add("Фамилия", "Фамилия");
            dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns.Add("Отчество", "Отчество");
            dataGridView1.Columns.Add("Контактный телефон", "Контактный телефон");
            foreach (var row in list)
            {
                dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
            }
            dataGridView1.Refresh();
        }

        private void showButton2_Click(object sender, EventArgs e)
        {
            string query = "select * from Работодатели";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("id работодателя", "id работодателя");
            dataGridView2.Columns.Add("Название предприятия", "Название предприятия");
            dataGridView2.Columns.Add("Вид деятельности", "Вид деятельности");
            dataGridView2.Columns.Add("Адрес", "Адрес");
            dataGridView2.Columns.Add("Телефон", "Телефон");
            foreach (var row in list)
            {
                IdentityItem row2 = DBConnectionService.SendQueryToSqlServer("select [id деятельности], [Вид деятельности] from [Виды деятельности] where [id деятельности] = " + row[2]).Select(f => new IdentityItem(f[0], f[1])).FirstOrDefault();
                dataGridView2.Rows.Add(row[0], row[1], row2, row[3], row[4]);
            }
            dataGridView2.Refresh();
        }

        private void showButton3_Click(object sender, EventArgs e)
        {
            string query = "select * from Вакансии";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView3.Columns.Add("id вакансии", "id вакансии");
            dataGridView3.Columns.Add("Название предприятия", "Название предприятия");
            dataGridView3.Columns.Add("Должность", "Должность");
            dataGridView3.Columns.Add("Требуемый уровень образования", "Требуемый уровень образования");
            dataGridView3.Columns.Add("Квалификация", "Квалификация");
            dataGridView3.Columns.Add("Заработная плата", "Заработная плата");
            dataGridView3.Columns.Add("Открытая", "Открытая");
            foreach (var row in list)
            {
                IdentityItem row1 = DBConnectionService.SendQueryToSqlServer("select [id работодателя], [Название предприятия] from Работодатели where [id работодателя] = " + row[1]).Select(f => new IdentityItem(f[0], f[1])).FirstOrDefault();
                IdentityItem row2 = DBConnectionService.SendQueryToSqlServer("select [id должности], Должность from Должности where [id должности] = " + row[2]).Select(f => new IdentityItem(f[0], f[1])).FirstOrDefault();
                dataGridView3.Rows.Add(row[0], row1, row2, row[3], row[4], row[5], row[6]);
            }
            dataGridView3.Refresh();
        }

        private void showButton4_Click(object sender, EventArgs e)
        {
            string query = "select * from Соискатели";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            dataGridView4.Columns.Add("id соискателя", "id соискателя");
            dataGridView4.Columns.Add("Фамилия", "Фамилия");
            dataGridView4.Columns.Add("Имя", "Имя");
            dataGridView4.Columns.Add("Отчество", "Отчество");
            dataGridView4.Columns.Add("Год рождения", "Год рождения");
            dataGridView4.Columns.Add("Образование", "Образование");
            dataGridView4.Columns.Add("Должность", "Должность");
            dataGridView4.Columns.Add("Квалификация", "Квалификация");
            dataGridView4.Columns.Add("Предполагаемый размер заработной платы", "Предполагаемый размер заработной платы");
            foreach (var row in list)
            {
                IdentityItem row6 = DBConnectionService.SendQueryToSqlServer("select [id должности], Должность from Должности where [id должности] = " + row[6]).Select(f => new IdentityItem(f[0], f[1])).FirstOrDefault();
                dataGridView4.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row6, row[7], row[8]);
            }
            dataGridView4.Refresh();
        }

        private void showButton5_Click(object sender, EventArgs e)
        {
            string query = "select * from Сделки";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView5.Rows.Clear();
            dataGridView5.Columns.Clear();
            dataGridView5.Columns.Add("id сделки", "id сделки");
            dataGridView5.Columns.Add("Соискатель", "Соискатель");
            dataGridView5.Columns.Add("Вакансия", "Вакансия");
            dataGridView5.Columns.Add("Агент", "Агент");
            dataGridView5.Columns.Add("Дата заключения", "Дата заключения");
            dataGridView5.Columns.Add("Комиссионные", "Комиссионные");


            foreach (var row in list)
            {
                IdentityItem row1 = DBConnectionService.SendQueryToSqlServer("select [id соискателя], (Фамилия+' '+Имя+' '+Отчество) from Соискатели where [id соискателя] = " + row[1]).Select(f => new IdentityItem(f[0], f[1])).FirstOrDefault();
                IdentityItem row2 = DBConnectionService.SendQueryToSqlServer("select [id вакансии], ([Должность]+' '+[Заработная плата]) from Вакансии, Должности where [id вакансии] = " + row[2]).Select(f => new IdentityItem(f[0], f[1])).FirstOrDefault();
                IdentityItem row3 = DBConnectionService.SendQueryToSqlServer("select [id агента], (Фамилия+' '+[Контактный телефон]) from [Агенты бюро] where [id агента] = " + row[3]).Select(f => new IdentityItem(f[0], f[1])).FirstOrDefault();
                dataGridView5.Rows.Add(row[0], row1, row2, row3, row[4], row[5]);
            }
            dataGridView5.Refresh();
        }

        private void showButton6_Click(object sender, EventArgs e)
        {
            string query = "select * from [Виды деятельности]";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView6.Rows.Clear();
            dataGridView6.Columns.Clear();
            dataGridView6.Columns.Add("id деятельности", "id деятельности");
            dataGridView6.Columns.Add("Вид деятельности", "Вид деятельности");
            foreach (var row in list)
            {
                dataGridView6.Rows.Add(row[0], row[1]);
            }
            dataGridView6.Refresh();
        }

        private void showButton7_Click(object sender, EventArgs e)
        {
            string query = "select * from [Должности]";
            var list = DBConnectionService.SendQueryToSqlServer(query);
            if (list == null || !list.Any())
            {
                return;
            }
            dataGridView7.Rows.Clear();
            dataGridView7.Columns.Clear();
            dataGridView7.Columns.Add("id должности", "id должности");
            dataGridView7.Columns.Add("Должность", "Должность");
            foreach (var row in list)
            {
                dataGridView7.Rows.Add(row[0], row[1]);
            }
            dataGridView7.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)                          // Вывод значений строки таблицы на поля вкладки изменения
        {
            fBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            iBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            oBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            ktBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            npBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            vdComboBox1.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            aBox1.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            tBox1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            npComboBox1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            dBox1.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            tuoBox1.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            kBox1.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            zpBox1.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            if (dataGridView3.CurrentRow.Cells[6].Value.ToString() == "True") radioButton3.PerformClick();
            if (dataGridView3.CurrentRow.Cells[6].Value.ToString() == "False") radioButton4.PerformClick();

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fBox3.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            iBox3.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            oBox3.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView4.CurrentRow.Cells[4].Value);
            obrBox1.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            dBox3.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
            kBox3.Text = dataGridView4.CurrentRow.Cells[7].Value.ToString();
            przpBox1.Text = dataGridView4.CurrentRow.Cells[8].Value.ToString();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            SComboBox1.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            VComboBox1.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            AComboBox1.Text = dataGridView5.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker4.Value = Convert.ToDateTime(dataGridView5.CurrentRow.Cells[4].Value);
            kmsBox1.Text = dataGridView5.CurrentRow.Cells[5].Value.ToString();
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vdBox1.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            originalDBox2.Text = dataGridView7.CurrentRow.Cells[1].Value.ToString();
        }

        private void delButton1_Click(object sender, EventArgs e)                                                           // Кнопки удалений
        {
            int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string query = "DELETE FROM [Агенты бюро] WHERE [id агента] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delButton2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            string query = "DELETE FROM Работодатели WHERE [id работодателя] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delButton3_Click(object sender, EventArgs e)
        {
            int n = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            string query = "DELETE FROM Вакансии WHERE [id вакансии] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delButton4_Click(object sender, EventArgs e)
        {
            int n = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            string query = "DELETE FROM Соискатели WHERE [id соискателя] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delButton5_Click(object sender, EventArgs e)
        {
            int n = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString());
            string query = "DELETE FROM Сделки WHERE [id сделки] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delButton6_Click(object sender, EventArgs e)
        {
            int n = int.Parse(dataGridView6.CurrentRow.Cells[0].Value.ToString());
            string query = "DELETE FROM [Виды деятельности] WHERE [id деятельности] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delButton7_Click(object sender, EventArgs e)
        {
            int n = int.Parse(dataGridView7.CurrentRow.Cells[0].Value.ToString());
            string query = "DELETE FROM [Должности] WHERE [id должности] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addAgentButton_Click(object sender, EventArgs e)                                                    // Агенты бюро (Добавление)
        {
            string f = null;
            string i = null;
            string o = null;
            string kt = null;
            try
            {
                f = fBox.Text;
                i = iBox.Text;
                o = oBox.Text;
                kt = ktBox.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fBox.Text != String.Empty && iBox.Text != String.Empty && oBox.Text != String.Empty)
            {
                string query = "insert into [Агенты бюро] (Фамилия, Имя, Отчество, [Контактный телефон])" +
                "values (" + $"'{f}','{i}','{o}','{kt}'" + ")";
                int? result = DBConnectionService.SendCommandToSqlServer(query);
                if (result != null && result > 0)
                {
                    MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showButton1.PerformClick();
                    fBox.Clear();
                    iBox.Clear();
                    oBox.Clear();
                    ktBox.Clear();
                }
            }
            else MessageBox.Show("Не все поля заполнены");
        }

        private void updAgentButton_Click(object sender, EventArgs e)                                                  // Агенты бюро (Изменение)
        {
            string f = null;
            string i = null;
            string o = null;
            string kt = null;
            try
            {
                f = fBox1.Text;
                i = iBox1.Text;
                o = oBox1.Text;
                kt = ktBox1.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string query = "UPDATE [Агенты бюро] SET Фамилия = '" + f + "', Имя = '" + i + "', Отчество = '" + o + "', [Контактный телефон] = '" + kt + "'" +
                "WHERE [id агента] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton1.PerformClick();
            }
        }

        private void addRButton_Click(object sender, EventArgs e)                                                       // Работодатели (Добавление)
        {
            string np = null;
            int? vd = null;
            string a = null;
            string t = null;
            try
            {
                np = npBox.Text;
                vd = Convert.ToInt32((vdComboBox.SelectedItem as IdentityItem)?.Id);
                a = aBox.Text;
                t = tBox.Text;
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
                showButton2.PerformClick();
                npBox.Clear();
                vdComboBox.SelectedIndex = -1;
                aBox.Clear();
                tBox.Clear();
            }
        }

        private void vdComboBox_DropDown(object sender, EventArgs e)                                                      // Комбобокс "Вид деятельности"
        {
            string query = "select [id деятельности], [Вид деятельности] from [Виды деятельности]";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            ((ComboBox)sender).Items.Clear();
            ((ComboBox)sender).Items.AddRange(list);
        }

        private void updRButton_Click(object sender, EventArgs e)                                                         // Работодатели (Изменение)
        {
            string np = null;
            int? vd = null;
            string a = null;
            string t = null;
            try
            {
                np = npBox1.Text;
                vd = Convert.ToInt32((vdComboBox1.SelectedItem as IdentityItem)?.Id);
                a = aBox1.Text;
                t = tBox1.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            string query = "UPDATE Работодатели SET [Название предприятия] = '" + np + "', [id деятельности] = '" + vd + "', Адрес = '" + a + "', Телефон = '" + t + "'" +
                "WHERE [id работодателя] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton2.PerformClick();
            }
        }

        private void addVButton_Click(object sender, EventArgs e)                                                                // Вакансии (Добавление)
        {
            int? np = null;
            int? d = null;
            string tuo = null;
            string k = null;
            string zp = null;
            try
            {
                np = Convert.ToInt32((npComboBox.SelectedItem as IdentityItem)?.Id);
                d = Convert.ToInt32((dBox.SelectedItem as IdentityItem)?.Id);
                tuo = tuoBox.Text;
                k = kBox.Text;
                zp = zpBox.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "insert into Вакансии ([id работодателя], [id должности], [Требуемый уровень образования], Квалификация, [Заработная плата], Открытая)" +
                "values (" + $"'{np}','{d}','{tuo}','{k}','{zp}','{tip1}'" + ")";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton3.PerformClick();
                npComboBox.SelectedIndex = -1;
                dBox.SelectedIndex = -1;
                tuoBox.Clear();
                kBox.Clear();
                zpBox.Clear();
            }
        }

        private void npComboBox_DropDown(object sender, EventArgs e)                                                           // Комбобокс "Название предприятия"
        {
            string query = "select [id работодателя], [Название предприятия] from Работодатели";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            ((ComboBox)sender).Items.Clear();
            ((ComboBox)sender).Items.AddRange(list);
        }

        private void dBox_DropDown(object sender, EventArgs e)                                                                 // Комбобокс "Должности"
        {
            string query = "select [id должности], Должность from Должности";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            ((ComboBox)sender).Items.Clear();
            ((ComboBox)sender).Items.AddRange(list);
        }

        private void updVButton_Click(object sender, EventArgs e)                                                               // Вакансии (Изменение)
        {
            int? np = null;
            int? d = null;
            string tuo = null;
            string k = null;
            string zp = null;
            try
            {
                np = Convert.ToInt32((npComboBox1.SelectedItem as IdentityItem)?.Id);
                d = Convert.ToInt32((dBox1.SelectedItem as IdentityItem)?.Id);
                tuo = tuoBox1.Text;
                k = kBox1.Text;
                zp = zpBox1.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            string query = "UPDATE Вакансии SET [id работодателя] = '" + np + "', [id должности] = '" + d + "'" +
                ", [Требуемый уровень образования] = '" + tuo + "', [Квалификация] = '" + k + "', [Заработная плата] = '" + zp + "', Открытая = '" + tip2 + "'" +
                "WHERE [id вакансии] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton3.PerformClick();
            }
        }

        private void addSButton_Click(object sender, EventArgs e)                                                              // Соискатели (Добавление)
        {
            string f = null;
            string i = null;
            string o = null;
            DateTime gr;
            string obr = null;
            int? d = null;
            string k = null;
            string przr = null;
            try
            {
                f = fBox2.Text;
                i = iBox2.Text;
                o = oBox2.Text;
                gr = dateTimePicker1.Value;
                obr = obrBox.Text;
                d = Convert.ToInt32((dBox2.SelectedItem as IdentityItem)?.Id);
                k = kBox2.Text;
                przr = przpBox.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into Соискатели (Фамилия, Имя, Отчество, [Год рождения], Образование, [id должности], Квалификация, [Предполагаемый размер заработной платы])" +
                "values (" + $"'{f}','{i}','{o}','{gr}','{obr}','{d}','{k}','{przr}'" + ")";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton4.PerformClick();
                fBox2.Clear();
                iBox2.Clear();
                oBox2.Clear();
                dateTimePicker1.Value = DateTime.Now;
                obrBox.Clear();
                dBox2.SelectedIndex = -1;
                kBox2.Clear();
                przpBox.Clear();
            }
        }

        private void updSButton_Click(object sender, EventArgs e)                                                               // Соискатели (Изменение)
        {
            string f = null;
            string i = null;
            string o = null;
            DateTime gr;
            string obr = null;
            int? d = null;
            string k = null;
            string przr = null;
            try
            {
                f = fBox3.Text;
                i = iBox3.Text;
                o = oBox3.Text;
                gr = dateTimePicker2.Value;
                obr = obrBox1.Text;
                d = Convert.ToInt32((dBox3.SelectedItem as IdentityItem)?.Id);
                k = kBox3.Text;
                przr = przpBox1.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            string query = "UPDATE Соискатели SET Фамилия = '" + f + "', Имя = '" + i + "', Отчество = '" + o + "'" +
                ", [Год рождения] = '" + gr + "', Образование = '" + obr + "', [id должности] = '" + d + "'" +
                ", Квалификация = '" + k + "', [Предполагаемый размер заработной платы] = '" + przr + "'" +
                "WHERE [id соискателя] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton4.PerformClick();
            }
        }

        private void addSdButton_Click(object sender, EventArgs e)                                                         // Сделки (Добавление)
        {
            DateTime dz;
            int? s = null;
            int? v = null;
            int? a = null;
            string kms = null;
            try
            {
                dz = dateTimePicker3.Value;
                s = Convert.ToInt32((SComboBox.SelectedItem as IdentityItem)?.Id);
                v = Convert.ToInt32((VComboBox.SelectedItem as IdentityItem)?.Id);
                a = Convert.ToInt32((AComboBox.SelectedItem as IdentityItem)?.Id);
                kms = kmsBox.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into Сделки ([Дата заключения], [id соискателя], [id вакансии], [id агента], Комиссионные)" +
                "values (" + $"'{dz}','{s}','{v}','{a}','{kms}'" + ")";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton5.PerformClick();
                dateTimePicker3.Value = DateTime.Now;
                SComboBox.SelectedIndex = -1;
                VComboBox.SelectedIndex = -1;
                AComboBox.SelectedIndex = -1;
                kmsBox.Clear();
            }
        }

        private void SComboBox_DropDown(object sender, EventArgs e)                                                         // Комбобокс "Соискатель"
        {
            string query = "select [id соискателя], (Фамилия+' '+Имя+' '+Отчество) from Соискатели";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            ((ComboBox)sender).Items.Clear();
            ((ComboBox)sender).Items.AddRange(list);
        }

        private void VComboBox_DropDown(object sender, EventArgs e)                                                         // Комбобокс "Вакансия"
        {
            string query = "select Вакансии.[id вакансии], (Должности.[Должность]+' '+Вакансии.[Заработная плата]) from Вакансии Join Должности on Вакансии.[id должности] = Должности.[id должности]";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            ((ComboBox)sender).Items.Clear();
            ((ComboBox)sender).Items.AddRange(list);
        }

        private void AComboBox_DropDown(object sender, EventArgs e)                                                         // Комбобокс "Агент бюро"
        {
            string query = "select [id агента], (Фамилия+' '+[Контактный телефон]) from [Агенты бюро]";
            var list = DBConnectionService.SendQueryToSqlServer(query)?.Select(row => new IdentityItem(row[0], row[1])).ToArray();
            ((ComboBox)sender).Items.Clear();
            ((ComboBox)sender).Items.AddRange(list);
        }

        private void updSdButton_Click(object sender, EventArgs e)                                                          // Сделки (Изменение)
        {
            int? s = null;
            int? v = null;
            int? a = null;
            DateTime dz;
            string kms = null;
            try
            {
                s = Convert.ToInt32((SComboBox1.SelectedItem as IdentityItem)?.Id);
                v = Convert.ToInt32((VComboBox1.SelectedItem as IdentityItem)?.Id);
                a = Convert.ToInt32((AComboBox1.SelectedItem as IdentityItem)?.Id);
                dz = dateTimePicker4.Value;
                kms = kmsBox1.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString());
            string query = "UPDATE Сделки SET [Дата заключения] = '" + dz + "', [id соискателя] = '" + s + "', [id вакансии] = '" + v + "', " +
                "[id агента] = '" + a + "', [Комиссионные] = '" + kms + "' WHERE [id сделки] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton5.PerformClick();
            }
        }

        private void addVDButton_Click(object sender, EventArgs e)                                                             // Виды деятельности (Добавление)
        {
            string vd = null;
            try
            {
                vd = vdBox.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into [Виды деятельности] ([Вид деятельности])" +
                "values ('" + vd + "')";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton6.PerformClick();
                vdBox.Clear();
            }
        }

        private void updVDButton_Click(object sender, EventArgs e)                                                            // Виды деятельности (Изменение)
        {
            string vd = null;
            try
            {
                vd = vdBox1.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = int.Parse(dataGridView6.CurrentRow.Cells[0].Value.ToString());
            string query = "UPDATE [Виды деятельности] SET [Вид деятельности] = '" + vd + "'" +
                "WHERE [id деятельности] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton6.PerformClick();
            }
        }

        private void addDButton_Click(object sender, EventArgs e)                                                             // Должности (Добавление)
        {
            string d = null;
            try
            {
                d = originalDBox1.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "insert into Должности (Должность)" +
                "values ('" + d + "')";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton7.PerformClick();
                originalDBox1.Clear();
            }
        }

        private void updDButton_Click(object sender, EventArgs e)                                                             // Должности (Изменение)
        {
            string d = null;
            try
            {
                d = originalDBox2.Text;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = int.Parse(dataGridView7.CurrentRow.Cells[0].Value.ToString());
            string query = "UPDATE Должности SET Должность = '" + d + "'" +
                "WHERE [id должности] = '" + n + "'";
            int? result = DBConnectionService.SendCommandToSqlServer(query);
            if (result != null && result > 0)
            {
                MessageBox.Show("Done", "Saving object", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showButton7.PerformClick();
            }
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

        private void fio_TextChanged(object sender, EventArgs e)                                                      // Ввод с заглавной
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

        private void fio_KeyPress(object sender, KeyPressEventArgs e)                                                 // Ввод только русских букв и BACKSPACE
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void ktBox_MouseClick(object sender, MouseEventArgs e)                                                // Нормальное положение курсора в MaskedTextBox
        {
            ((MaskedTextBox)sender).SelectionStart = ((MaskedTextBox)sender).MaskedTextProvider.LastAssignedPosition + 1;
            ((MaskedTextBox)sender).SelectionLength = 0;
        }

        private void zpBox_KeyPress(object sender, KeyPressEventArgs e)                                               // Ввод суммы денег
        {
            // Менять запятую на точку
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            // Только цифры, точка, BACKSPACE
            if (e.KeyChar < '0' | e.KeyChar > '9' && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {

                e.Handled = true;
            }

            // Точка не первая
            if (((TextBox)sender).SelectionStart == 0 & e.KeyChar == '.')
            {
                e.Handled = true;
            }

            // Если первая - 0, то вторая только точка 
            if (((TextBox)sender).Text == "0")
            {
                if (e.KeyChar != '.' & e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }

            // Только 2 знака после точки
            if (((TextBox)sender).Text.IndexOf('.') > 0)
            {
                if (((TextBox)sender).Text.Substring(((TextBox)sender).Text.IndexOf('.')).Length > 2)
                {
                    if (e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                }
            }

            // Только 1 точка
            if (e.KeyChar == '.')
            {
                if (((TextBox)sender).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void SComboBox_KeyPress(object sender, KeyPressEventArgs e)                                // Запрет ввода в комбобокс
        {
            e.Handled = true;
        }
    }
}
