using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Прописываем SQL команду 
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [FirstChart] (Y0, X0, Y1, X1, Y2, X2, Y3, X3) VALUES (@Y0, @X0, @Y1, @X1, @Y2, @X2, @Y3, @X3)", sqlConnection);

            command.Parameters.AddWithValue("Y0", Convert.ToDouble(textBox1.Text));
            command.Parameters.AddWithValue("X0", Convert.ToDouble(textBox2.Text));
            command.Parameters.AddWithValue("Y1", Convert.ToDouble(textBox3.Text));
            command.Parameters.AddWithValue("X1", Convert.ToDouble(textBox4.Text));
            command.Parameters.AddWithValue("Y2", Convert.ToDouble(textBox5.Text));
            command.Parameters.AddWithValue("X2", Convert.ToDouble(textBox6.Text));
            command.Parameters.AddWithValue("Y3", Convert.ToDouble(textBox7.Text));
            command.Parameters.AddWithValue("X3", Convert.ToDouble(textBox8.Text));
            // Добавляем все значения в БД
            command.ExecuteNonQuery();
            // Закрываем дополнительное окно
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Устанавливаем соединение с БД
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            // Проверяем соединение с БД
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение установлено!");
            }

            if (radioButton2Points.Checked == true)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
        }

        private void radioButton2Points_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void radioButton3Points_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = false;
        }

        private void radioButton4Points_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddLine_Click(object sender, EventArgs e)
        {
            var newTextBox1 = new TextBox();
            newTextBox1.Top = textBox1.Location.Y + textBox1.Size.Height + 5;
            newTextBox1.Left = textBox1.Location.X;
            newTextBox1.Width = 100;
            newTextBox1.Height = 20;
            Controls.Add(newTextBox1);
        }
    }
}
