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
        private List<Label> listOfLabels = new List<Label>();
        private List<ComboBox> listOfComboBoxes = new List<ComboBox>();
        private List<TextBox> listOfTextBoxes = new List<TextBox>();
        private List<TextBox> listOfTextBoxesForColor = new List<TextBox>();
        private SqlConnection sqlConnection = null;
        private string query;
        private SqlCommand command;

        public Form2()
        {
            InitializeComponent();
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
            comboBox1.SelectedItem = "4 точки";
        }

        private void buttonAddDiagram_Click(object sender, EventArgs e)
        {
            addFirstLineInDB();
            addAnotherLinesInDB();
            //// Прописываем SQL команду 
            //SqlCommand command = new SqlCommand(
            //    $"INSERT INTO [FirstChart] (Y0, X0, Y1, X1, Y2, X2, Y3, X3) VALUES (@Y0, @X0, @Y1, @X1, @Y2, @X2, @Y3, @X3)", sqlConnection);

            //command.Parameters.AddWithValue("X0", Convert.ToDouble(textBox1.Text));
            //command.Parameters.AddWithValue("Y0", Convert.ToDouble(textBox2.Text));
            //command.Parameters.AddWithValue("X1", Convert.ToDouble(textBox3.Text));
            //command.Parameters.AddWithValue("Y1", Convert.ToDouble(textBox4.Text));
            //command.Parameters.AddWithValue("X2", Convert.ToDouble(textBox5.Text));
            //command.Parameters.AddWithValue("Y2", Convert.ToDouble(textBox6.Text));
            //command.Parameters.AddWithValue("X3", Convert.ToDouble(textBox7.Text));
            //command.Parameters.AddWithValue("Y3", Convert.ToDouble(textBox8.Text));
            //// Добавляем все значения в БД
            //command.ExecuteNonQuery();
        }

        // Добавление новой таблицы в БД. Название берётся из поля на форме
        private void addNewTable()
        {
            String query = string.Format("CREATE TABLE [{0}] (" +
                            "Id INT IDENTITY (1,1) PRIMARY KEY, " +
                            "X0 FLOAT NOT NULL, " +
                            "Y0 FLOAT NOT NULL, " +
                            "X1 FLOAT DEFAULT ((-300)) NULL, " +
                            "Y1 FLOAT DEFAULT ((-300)) NULL, " +
                            "X2 FLOAT DEFAULT ((-300)) NULL, " +
                            "Y2 FLOAT DEFAULT ((-300)) NULL, " +
                            "X3 FLOAT NOT NULL, " +
                            "Y3 FLOAT NOT NULL, " +
                            "NumberOfColorGroup1 INT DEFAULT ((-300)) NULL, " +
                            "NumberOfColorGroup2 INT DEFAULT ((-300)) NULL)", nameOfDiagram.Text.Replace("-", ""));

            SqlCommand addTable = new SqlCommand(query, sqlConnection);
            try
            {
                addTable.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Данная диаграмма уже зарегистрирована в базе!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Метод для добавления строки
        private void buttonAddLine_Click(object sender, EventArgs e)
        {
            addNumberLabel();
            addComboBox();
            addLineOfTextBoxes();
            addLineOfTextBoxesForColor();
        }

        private void deleteLineButton_Click(object sender, EventArgs e)
        {
            deleteRowsFromForm();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFirstTextBoxStatus();
        }

        private void buttonChangeNumberOfPoints_Click(object sender, EventArgs e)
        {
            changeTextBoxesStatus();
        }

        // Метод для добавления линии полей для текста на форму
        private void addLineOfTextBoxes()
        {
            // Добавляем 8 полей для текста на форму
            listOfTextBoxes.Add(new TextBox());
            listOfTextBoxes.Add(new TextBox());
            listOfTextBoxes.Add(new TextBox());
            listOfTextBoxes.Add(new TextBox());
            listOfTextBoxes.Add(new TextBox());
            listOfTextBoxes.Add(new TextBox());
            listOfTextBoxes.Add(new TextBox());
            listOfTextBoxes.Add(new TextBox());

            if (listOfTextBoxes.Count == 8)
            {
                // Задаём координаты для всех полей второй строки
                // Первое поле
                listOfTextBoxes[0].Top = textBox1.Location.Y + textBox1.Size.Height + 5;
                listOfTextBoxes[0].Left = textBox1.Location.X;
                listOfTextBoxes[0].Width = textBox1.Size.Width;
                listOfTextBoxes[0].Height = textBox1.Size.Height;
                // Второе поле
                listOfTextBoxes[1].Top = textBox2.Location.Y + textBox2.Size.Height + 5;
                listOfTextBoxes[1].Left = textBox2.Location.X;
                listOfTextBoxes[1].Width = textBox2.Size.Width;
                listOfTextBoxes[1].Height = textBox2.Size.Height;
                // Третье поле
                listOfTextBoxes[2].Top = textBox3.Location.Y + textBox3.Size.Height + 5;
                listOfTextBoxes[2].Left = textBox3.Location.X;
                listOfTextBoxes[2].Width = textBox3.Size.Width;
                listOfTextBoxes[2].Height = textBox3.Size.Height;
                // Четвёртое поле
                listOfTextBoxes[3].Top = textBox4.Location.Y + textBox4.Size.Height + 5;
                listOfTextBoxes[3].Left = textBox4.Location.X;
                listOfTextBoxes[3].Width = textBox4.Size.Width;
                listOfTextBoxes[3].Height = textBox4.Size.Height;
                // Пятое поле
                listOfTextBoxes[4].Top = textBox5.Location.Y + textBox5.Size.Height + 5;
                listOfTextBoxes[4].Left = textBox5.Location.X;
                listOfTextBoxes[4].Width = textBox5.Size.Width;
                listOfTextBoxes[4].Height = textBox5.Size.Height;
                // Шестое поле
                listOfTextBoxes[5].Top = textBox6.Location.Y + textBox6.Size.Height + 5;
                listOfTextBoxes[5].Left = textBox6.Location.X;
                listOfTextBoxes[5].Width = textBox6.Size.Width;
                listOfTextBoxes[5].Height = textBox6.Size.Height;
                // Седьмое поле
                listOfTextBoxes[6].Top = textBox7.Location.Y + textBox7.Size.Height + 5;
                listOfTextBoxes[6].Left = textBox7.Location.X;
                listOfTextBoxes[6].Width = textBox7.Size.Width;
                listOfTextBoxes[6].Height = textBox7.Size.Height;
                // Восьмое поле
                listOfTextBoxes[7].Top = textBox8.Location.Y + textBox8.Size.Height + 5;
                listOfTextBoxes[7].Left = textBox8.Location.X;
                listOfTextBoxes[7].Width = textBox8.Size.Width;
                listOfTextBoxes[7].Height = textBox8.Size.Height;
                // Добавляем все новые поля на форму
                Controls.Add(listOfTextBoxes[0]);
                Controls.Add(listOfTextBoxes[1]);
                Controls.Add(listOfTextBoxes[2]);
                Controls.Add(listOfTextBoxes[3]);
                Controls.Add(listOfTextBoxes[4]);
                Controls.Add(listOfTextBoxes[5]);
                Controls.Add(listOfTextBoxes[6]);
                Controls.Add(listOfTextBoxes[7]);
            }
            else
            {
                // Задаём координаты для любой строки, которая будет ниже второй
                // Первое поле
                listOfTextBoxes[listOfTextBoxes.Count - 8].Top = listOfTextBoxes[listOfTextBoxes.Count - 16].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 16].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 8].Left = listOfTextBoxes[listOfTextBoxes.Count - 16].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 8].Width = listOfTextBoxes[listOfTextBoxes.Count - 16].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 8].Height = listOfTextBoxes[listOfTextBoxes.Count - 16].Size.Height;
                // Второе поле
                listOfTextBoxes[listOfTextBoxes.Count - 7].Top = listOfTextBoxes[listOfTextBoxes.Count - 15].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 15].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 7].Left = listOfTextBoxes[listOfTextBoxes.Count - 15].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 7].Width = listOfTextBoxes[listOfTextBoxes.Count - 15].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 7].Height = listOfTextBoxes[listOfTextBoxes.Count - 15].Size.Height;
                // Третье поле
                listOfTextBoxes[listOfTextBoxes.Count - 6].Top = listOfTextBoxes[listOfTextBoxes.Count - 14].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 14].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 6].Left = listOfTextBoxes[listOfTextBoxes.Count - 14].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 6].Width = listOfTextBoxes[listOfTextBoxes.Count - 14].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 6].Height = listOfTextBoxes[listOfTextBoxes.Count - 14].Size.Height;
                // Четвёртое поле
                listOfTextBoxes[listOfTextBoxes.Count - 5].Top = listOfTextBoxes[listOfTextBoxes.Count - 13].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 13].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 5].Left = listOfTextBoxes[listOfTextBoxes.Count - 13].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 5].Width = listOfTextBoxes[listOfTextBoxes.Count - 13].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 5].Height = listOfTextBoxes[listOfTextBoxes.Count - 13].Size.Height;
                // Пятое поле
                listOfTextBoxes[listOfTextBoxes.Count - 4].Top = listOfTextBoxes[listOfTextBoxes.Count - 12].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 12].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 4].Left = listOfTextBoxes[listOfTextBoxes.Count - 12].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 4].Width = listOfTextBoxes[listOfTextBoxes.Count - 12].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 4].Height = listOfTextBoxes[listOfTextBoxes.Count - 12].Size.Height;
                // Шестое поле
                listOfTextBoxes[listOfTextBoxes.Count - 3].Top = listOfTextBoxes[listOfTextBoxes.Count - 11].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 11].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 3].Left = listOfTextBoxes[listOfTextBoxes.Count - 11].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 3].Width = listOfTextBoxes[listOfTextBoxes.Count - 11].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 3].Height = listOfTextBoxes[listOfTextBoxes.Count - 11].Size.Height;
                // Седьмое поле
                listOfTextBoxes[listOfTextBoxes.Count - 2].Top = listOfTextBoxes[listOfTextBoxes.Count - 10].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 10].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 2].Left = listOfTextBoxes[listOfTextBoxes.Count - 10].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 2].Width = listOfTextBoxes[listOfTextBoxes.Count - 10].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 2].Height = listOfTextBoxes[listOfTextBoxes.Count - 10].Size.Height;
                // Восьмое поле
                listOfTextBoxes[listOfTextBoxes.Count - 1].Top = listOfTextBoxes[listOfTextBoxes.Count - 9].Location.Y + listOfTextBoxes[listOfTextBoxes.Count - 9].Size.Height + 5;
                listOfTextBoxes[listOfTextBoxes.Count - 1].Left = listOfTextBoxes[listOfTextBoxes.Count - 9].Location.X;
                listOfTextBoxes[listOfTextBoxes.Count - 1].Width = listOfTextBoxes[listOfTextBoxes.Count - 9].Size.Width;
                listOfTextBoxes[listOfTextBoxes.Count - 1].Height = listOfTextBoxes[listOfTextBoxes.Count - 9].Size.Height;
                // Добавляем все новые поля на форму
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 8]);
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 7]);
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 6]);
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 5]);
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 4]);
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 3]);
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 2]);
                Controls.Add(listOfTextBoxes[listOfTextBoxes.Count - 1]);
            }
        }

        // Метод для добавления двух текстовых полей для задания цветовых групп
        private void addLineOfTextBoxesForColor()
        {
            // Добавляем 2 поля для текста на форму
            listOfTextBoxesForColor.Add(new TextBox());
            listOfTextBoxesForColor.Add(new TextBox());

            if (listOfTextBoxesForColor.Count == 2)
            {
                // Задаём координаты для всех полей второй строки
                // Первое поле
                listOfTextBoxesForColor[0].Top = numberOfColorGroup1.Location.Y + numberOfColorGroup1.Size.Height + 5;
                listOfTextBoxesForColor[0].Left = numberOfColorGroup1.Location.X;
                listOfTextBoxesForColor[0].Width = numberOfColorGroup1.Size.Width;
                listOfTextBoxesForColor[0].Height = numberOfColorGroup1.Size.Height;
                // Второе поле
                listOfTextBoxesForColor[1].Top = numberOfColorGroup2.Location.Y + numberOfColorGroup2.Size.Height + 5;
                listOfTextBoxesForColor[1].Left = numberOfColorGroup2.Location.X;
                listOfTextBoxesForColor[1].Width = numberOfColorGroup2.Size.Width;
                listOfTextBoxesForColor[1].Height = numberOfColorGroup2.Size.Height;
                // Добавляем все новые поля на форму
                Controls.Add(listOfTextBoxesForColor[0]);
                Controls.Add(listOfTextBoxesForColor[1]);
            }
            else
            {
                // Задаём координаты для любой строки, которая будет ниже второй
                // Первое поле
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 2].Top = 
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 4].Location.Y +
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 4].Size.Height + 5;
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 2].Left = 
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 4].Location.X;
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 2].Width = 
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 4].Size.Width;
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 2].Height =
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 4].Size.Height;
                // Второе поле
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 1].Top = 
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 3].Location.Y + 
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 3].Size.Height + 5;
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 1].Left = 
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 3].Location.X;
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 1].Width =
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 3].Size.Width;
                listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 1].Height = 
                    listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 3].Size.Height;
                // Добавляем все новые поля на форму
                Controls.Add(listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 2]);
                Controls.Add(listOfTextBoxesForColor[listOfTextBoxesForColor.Count - 1]);
            }
        }

        // Метод для добавления комбо боксов для выбора количества точек, которые задают одну линию
        private void addComboBox()
        {
            listOfComboBoxes.Add(new ComboBox());

            if (listOfComboBoxes.Count == 1)
            {
                listOfComboBoxes[0].Top = comboBox1.Location.Y + comboBox1.Size.Height + 3;
                listOfComboBoxes[0].Left = comboBox1.Location.X;
                listOfComboBoxes[0].Width = comboBox1.Size.Width;
                listOfComboBoxes[0].Height = comboBox1.Size.Height;

                listOfComboBoxes[0].DropDownStyle = ComboBoxStyle.DropDownList;
                listOfComboBoxes[0].Items.Add("2 точки");
                listOfComboBoxes[0].Items.Add("3 точки");
                listOfComboBoxes[0].Items.Add("4 точки");
                listOfComboBoxes[0].SelectedItem = "4 точки";

                Controls.Add(listOfComboBoxes[0]);
            }
            else
            {
                listOfComboBoxes[listOfComboBoxes.Count - 1].Top = listOfComboBoxes[listOfComboBoxes.Count - 2].Location.Y + listOfComboBoxes[listOfComboBoxes.Count - 2].Size.Height + 3;
                listOfComboBoxes[listOfComboBoxes.Count - 1].Left = listOfComboBoxes[listOfComboBoxes.Count - 2].Location.X;
                listOfComboBoxes[listOfComboBoxes.Count - 1].Width = listOfComboBoxes[listOfComboBoxes.Count - 2].Size.Width;
                listOfComboBoxes[listOfComboBoxes.Count - 1].Height = listOfComboBoxes[listOfComboBoxes.Count - 2].Size.Height;

                listOfComboBoxes[listOfComboBoxes.Count - 1].DropDownStyle = ComboBoxStyle.DropDownList;
                listOfComboBoxes[listOfComboBoxes.Count - 1].Items.Add("2 точки");
                listOfComboBoxes[listOfComboBoxes.Count - 1].Items.Add("3 точки");
                listOfComboBoxes[listOfComboBoxes.Count - 1].Items.Add("4 точки");
                listOfComboBoxes[listOfComboBoxes.Count - 1].SelectedItem = "4 точки";

                Controls.Add(listOfComboBoxes[listOfComboBoxes.Count - 1]);
            }
        }

        // Метод для добавления поля, отображающего номер добавляемой линии
        private void addNumberLabel()
        {
            listOfLabels.Add(new Label());

            if (listOfLabels.Count == 1)
            {
                listOfLabels[0].Top = label3.Location.Y + label3.Size.Height + 8;
                listOfLabels[0].Left = label3.Location.X;
                listOfLabels[0].Width = label3.Size.Width;
                listOfLabels[0].Height = label3.Size.Height;

                listOfLabels[0].Text = Convert.ToString(int.Parse(label3.Text) + 1);
                listOfLabels[0].Font = new Font("Times New Roman", 10, FontStyle.Bold);

                Controls.Add(listOfLabels[0]);
            }
            else
            {
                listOfLabels[listOfLabels.Count - 1].Top = listOfLabels[listOfLabels.Count - 2].Location.Y + listOfLabels[listOfLabels.Count - 2].Size.Height + 8;
                listOfLabels[listOfLabels.Count - 1].Left = listOfLabels[listOfLabels.Count - 2].Location.X;
                listOfLabels[listOfLabels.Count - 1].Width = label3.Size.Width + 10;
                listOfLabels[listOfLabels.Count - 1].Height = label3.Size.Height;

                listOfLabels[listOfLabels.Count - 1].Text = Convert.ToString(int.Parse(listOfLabels[listOfLabels.Count - 2].Text) + 1);
                listOfLabels[listOfLabels.Count - 1].Font = new Font("Times New Roman", 10, FontStyle.Bold);

                Controls.Add(listOfLabels[listOfLabels.Count - 1]);
            }
        }

        // Метод для переключения статуса полей для текста
        private void changeTextBoxesStatus()
        {
            for (int i = 0; i < listOfComboBoxes.Count; i++)
            {
                if (listOfComboBoxes[i].SelectedItem.Equals("2 точки"))
                {
                    listOfTextBoxes[(i * 8) + 2].Enabled = false;
                    listOfTextBoxes[(i * 8) + 3].Enabled = false;
                    listOfTextBoxes[(i * 8) + 4].Enabled = false;
                    listOfTextBoxes[(i * 8) + 5].Enabled = false;
                }
                else if (listOfComboBoxes[i].SelectedItem.Equals("3 точки"))
                {
                    listOfTextBoxes[(i * 8) + 2].Enabled = true;
                    listOfTextBoxes[(i * 8) + 3].Enabled = true;
                    listOfTextBoxes[(i * 8) + 4].Enabled = false;
                    listOfTextBoxes[(i * 8) + 5].Enabled = false;
                }
                else if (listOfComboBoxes[i].SelectedItem.Equals("4 точки"))
                {
                    listOfTextBoxes[(i * 8) + 2].Enabled = true;
                    listOfTextBoxes[(i * 8) + 3].Enabled = true;
                    listOfTextBoxes[(i * 8) + 4].Enabled = true;
                    listOfTextBoxes[(i * 8) + 5].Enabled = true;
                }
            }
        }

        // Отдельный метод для изменения статусов у полей первой линии
        private void changeFirstTextBoxStatus()
        {
            if (comboBox1.SelectedItem.Equals("2 точки"))
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
            else if (comboBox1.SelectedItem.Equals("3 точки"))
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
            else if (comboBox1.SelectedItem.Equals("4 точки"))
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
            }
        }

        // Метод для добавления первой строчки в БД
        private void addFirstLineInDB()
        {
            query = string.Format("INSERT INTO [{0}] (X0, Y0, X1, Y1, X2, Y2, X3, Y3, NumberOfColorGroup1, NumberOfColorGroup2)" +
                       " VALUES (@X0, @Y0, @X1, @Y1, @X2, @Y2, @X3, @Y3, @NumberOfColorGroup1, @NumberOfColorGroup2)",
                       nameOfDiagram.Text.Replace("-", ""));
            if (String.IsNullOrEmpty(numberOfColorGroup1.Text) && !String.IsNullOrEmpty(numberOfColorGroup2.Text))
            {
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("NumberOfColorGroup1", -300);
                command.Parameters.AddWithValue("NumberOfColorGroup2", Convert.ToInt32(numberOfColorGroup2.Text));
            }
            else if (!String.IsNullOrEmpty(numberOfColorGroup1.Text) && String.IsNullOrEmpty(numberOfColorGroup2.Text))
            {
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("NumberOfColorGroup1", Convert.ToInt32(numberOfColorGroup1.Text));
                command.Parameters.AddWithValue("NumberOfColorGroup2", -300);
            }
            else if (String.IsNullOrEmpty(numberOfColorGroup1.Text) && String.IsNullOrEmpty(numberOfColorGroup2.Text))
            {
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("NumberOfColorGroup1", -300);
                command.Parameters.AddWithValue("NumberOfColorGroup2", -300);
            }
            else
            {
                command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("NumberOfColorGroup1", Convert.ToInt32(numberOfColorGroup1.Text));
                command.Parameters.AddWithValue("NumberOfColorGroup2", Convert.ToInt32(numberOfColorGroup2.Text));
            }
            try
            {
                switch (comboBox1.SelectedItem)
                {
                    case "2 точки":
                        command.Parameters.AddWithValue("X0", Convert.ToDouble(textBox1.Text));
                        command.Parameters.AddWithValue("Y0", Convert.ToDouble(textBox2.Text));
                        command.Parameters.AddWithValue("X1", -300);
                        command.Parameters.AddWithValue("Y1", -300);
                        command.Parameters.AddWithValue("X2", -300);
                        command.Parameters.AddWithValue("Y2", -300);
                        command.Parameters.AddWithValue("X3", Convert.ToDouble(textBox7.Text));
                        command.Parameters.AddWithValue("Y3", Convert.ToDouble(textBox8.Text));

                        break;
                    case "3 точки":
                        command.Parameters.AddWithValue("X0", Convert.ToDouble(textBox1.Text));
                        command.Parameters.AddWithValue("Y0", Convert.ToDouble(textBox2.Text));
                        command.Parameters.AddWithValue("X1", Convert.ToDouble(textBox3.Text));
                        command.Parameters.AddWithValue("Y1", Convert.ToDouble(textBox4.Text));
                        command.Parameters.AddWithValue("X2", -300);
                        command.Parameters.AddWithValue("Y2", -300);
                        command.Parameters.AddWithValue("X3", Convert.ToDouble(textBox7.Text));
                        command.Parameters.AddWithValue("Y3", Convert.ToDouble(textBox8.Text));

                        break;
                    case "4 точки":
                        command.Parameters.AddWithValue("X0", Convert.ToDouble(textBox1.Text));
                        command.Parameters.AddWithValue("Y0", Convert.ToDouble(textBox2.Text));
                        command.Parameters.AddWithValue("X1", Convert.ToDouble(textBox3.Text));
                        command.Parameters.AddWithValue("Y1", Convert.ToDouble(textBox4.Text));
                        command.Parameters.AddWithValue("X2", Convert.ToDouble(textBox5.Text));
                        command.Parameters.AddWithValue("Y2", Convert.ToDouble(textBox6.Text));
                        command.Parameters.AddWithValue("X3", Convert.ToDouble(textBox7.Text));
                        command.Parameters.AddWithValue("Y3", Convert.ToDouble(textBox8.Text));

                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните все поля координат точек!");
            }
            addNewTable();
            // Добавляем все значения в БД
            command.ExecuteNonQuery();
        }

        private void addAnotherLinesInDB()
        {
            try
            {
                for (int i = 0; i < listOfComboBoxes.Count; i++)
                {
                    query = string.Format("INSERT INTO [{0}] (X0, Y0, X1, Y1, X2, Y2, X3, Y3, NumberOfColorGroup1, NumberOfColorGroup2)" +
                       " VALUES (@X0, @Y0, @X1, @Y1, @X2, @Y2, @X3, @Y3, @NumberOfColorGroup1, @NumberOfColorGroup2)", 
                       nameOfDiagram.Text.Replace("-", ""));
                    if (String.IsNullOrEmpty(listOfTextBoxesForColor[(i * 2) + 0].Text) && !String.IsNullOrEmpty(listOfTextBoxesForColor[(i * 2) + 1].Text))
                    {
                        command = new SqlCommand(query, sqlConnection);
                        command.Parameters.AddWithValue("NumberOfColorGroup1", -300);
                        command.Parameters.AddWithValue("NumberOfColorGroup2", Convert.ToInt32(listOfTextBoxesForColor[(i * 2) + 1].Text));
                    }
                    else if (!String.IsNullOrEmpty(listOfTextBoxesForColor[(i * 2) + 0].Text) && String.IsNullOrEmpty(listOfTextBoxesForColor[(i * 2) + 1].Text))
                    {
                        command = new SqlCommand(query, sqlConnection);
                        command.Parameters.AddWithValue("NumberOfColorGroup1", Convert.ToInt32(listOfTextBoxesForColor[(i * 2) + 0].Text));
                        command.Parameters.AddWithValue("NumberOfColorGroup2", -300);
                    }
                    else if (String.IsNullOrEmpty(listOfTextBoxesForColor[(i * 2) + 0].Text) && String.IsNullOrEmpty(listOfTextBoxesForColor[(i * 2) + 1].Text))
                    {
                        command = new SqlCommand(query, sqlConnection);
                        command.Parameters.AddWithValue("NumberOfColorGroup1", -300);
                        command.Parameters.AddWithValue("NumberOfColorGroup2", -300);
                    }
                    else
                    {
                        command = new SqlCommand(query, sqlConnection);
                        command.Parameters.AddWithValue("NumberOfColorGroup1", Convert.ToInt32(listOfTextBoxesForColor[(i * 2) + 0].Text));
                        command.Parameters.AddWithValue("NumberOfColorGroup2", Convert.ToInt32(listOfTextBoxesForColor[(i * 2) + 1].Text));
                    }

                    switch (listOfComboBoxes[i].SelectedItem)
                    {
                        case "2 точки":
                            command.Parameters.AddWithValue("X0", Convert.ToDouble(listOfTextBoxes[(i * 8) + 0].Text));
                            command.Parameters.AddWithValue("Y0", Convert.ToDouble(listOfTextBoxes[(i * 8) + 1].Text));
                            command.Parameters.AddWithValue("X1", -300);
                            command.Parameters.AddWithValue("Y1", -300);
                            command.Parameters.AddWithValue("X2", -300);
                            command.Parameters.AddWithValue("Y2", -300);
                            command.Parameters.AddWithValue("X3", Convert.ToDouble(listOfTextBoxes[(i * 8) + 6].Text));
                            command.Parameters.AddWithValue("Y3", Convert.ToDouble(listOfTextBoxes[(i * 8) + 7].Text));

                            break;
                        case "3 точки":
                            command.Parameters.AddWithValue("X0", Convert.ToDouble(listOfTextBoxes[(i * 8) + 0].Text));
                            command.Parameters.AddWithValue("Y0", Convert.ToDouble(listOfTextBoxes[(i * 8) + 1].Text));
                            command.Parameters.AddWithValue("X1", Convert.ToDouble(listOfTextBoxes[(i * 8) + 2].Text));
                            command.Parameters.AddWithValue("Y1", Convert.ToDouble(listOfTextBoxes[(i * 8) + 3].Text));
                            command.Parameters.AddWithValue("X2", -300);
                            command.Parameters.AddWithValue("Y2", -300);
                            command.Parameters.AddWithValue("X3", Convert.ToDouble(listOfTextBoxes[(i * 8) + 6].Text));
                            command.Parameters.AddWithValue("Y3", Convert.ToDouble(listOfTextBoxes[(i * 8) + 7].Text));

                            break;
                        case "4 точки":
                            command.Parameters.AddWithValue("X0", Convert.ToDouble(listOfTextBoxes[(i * 8) + 0].Text));
                            command.Parameters.AddWithValue("Y0", Convert.ToDouble(listOfTextBoxes[(i * 8) + 1].Text));
                            command.Parameters.AddWithValue("X1", Convert.ToDouble(listOfTextBoxes[(i * 8) + 2].Text));
                            command.Parameters.AddWithValue("Y1", Convert.ToDouble(listOfTextBoxes[(i * 8) + 3].Text));
                            command.Parameters.AddWithValue("X2", Convert.ToDouble(listOfTextBoxes[(i * 8) + 4].Text));
                            command.Parameters.AddWithValue("Y2", Convert.ToDouble(listOfTextBoxes[(i * 8) + 5].Text));
                            command.Parameters.AddWithValue("X3", Convert.ToDouble(listOfTextBoxes[(i * 8) + 6].Text));
                            command.Parameters.AddWithValue("Y3", Convert.ToDouble(listOfTextBoxes[(i * 8) + 7].Text));

                            break;
                    }
                    // Добавляем все значения в БД
                    command.ExecuteNonQuery();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните все поля координат точек!");
            }

        }

        // Метод удаления строки для ввода значений одной линии
        private void deleteRowsFromForm()
        {
            // Удаляем комбобоксы
            listOfComboBoxes.Last().Dispose();
            listOfComboBoxes.Remove(listOfComboBoxes.Last());

            // Удаляем текстовые поля для задания цветовых групп
            listOfTextBoxesForColor.Last().Dispose();
            listOfTextBoxesForColor.Remove(listOfTextBoxesForColor.Last());
            listOfTextBoxesForColor.Last().Dispose();
            listOfTextBoxesForColor.Remove(listOfTextBoxesForColor.Last());

            // Удаляем текстовые поля для задания координат точек
            // Первое поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());
            // Второе поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());
            // Третье поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());
            // Четвёртое поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());
            // Пятое поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());
            // Шестое поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());
            // Седьмое поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());
            // Восьмое поле
            listOfTextBoxes.Last().Dispose();
            listOfTextBoxes.Remove(listOfTextBoxes.Last());

            // Удаляем номера строк
            listOfLabels.Last().Dispose();
            listOfLabels.Remove(listOfLabels.Last());
        }

        // Перегрузка построения по Безье для двух точек
        private List<double[]> bezierBuilding(double P0x, double P0y, double P3x, double P3y)
        {
            // Создаём два массива для значений по обеим осям + счётчик номера элемента
            double[] arrayX = new double[2];
            double[] arrayY = new double[2];

            arrayX[0] = P0x;
            arrayX[1] = P3x;

            arrayY[0] = P0y;
            arrayY[1] = P3y;

            formsPlot1.plt.PlotScatter(arrayX, arrayY, color: Color.Black, markerSize: 0);
            formsPlot1.plt.Axis(0, 7, 600, 1600);
            /*formsPlot1.plt.AxisBounds(0, 4.4, 1100, 1550);*/
            formsPlot1.Render();
            return new List<double[]> { arrayX, arrayY };
        }

        // Перегрузка построения по Безье для трёх точек
        private List<double[]> bezierBuilding(double P0x, double P0y, double P1xBefore, double Py, double P3x, double P3y)
        {
            double[] arrayForCheckY = new double[10001];
            double[] arrayForCheckX = new double[10001];
            // Создаём два массива для значений по обеим осям + счётчик номера элемента
            double[] arrayX = new double[10001];
            double[] arrayY = new double[10001];
            int i;

            double P1yBefore, P1x, P1y, P2x, P2y;
            for (double j = 0.50; j < 0.999; j += 0.001)
            {
                // Высчитываем координату y для одной направляющей точки
                P1yBefore = ((Py - (0.25 * P0y)) / j);
                // Пересчитываем координаты для двух направляющих точек
                P1x = P0x + ((2 * (P1xBefore - P0x)) / 3);
                P1y = P0y + ((2 * (P1yBefore - P0y)) / 3);
                P2x = P1xBefore + ((P3x - P1xBefore) / 3);
                P2y = P1yBefore + ((P3y - P1yBefore) / 3);
                i = 0;
                // Заполняем массивы по формулам построения кривых Безье
                for (double t = 0; t <= 1; t += 0.0001)
                {
                    arrayX[i] = Math.Pow((1 - t), 3) * P0x + 3 * t * Math.Pow((1 - t), 2) * P1x
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2x + Math.Pow(t, 3) * P3x;
                    arrayY[i] = Math.Pow((1 - t), 3) * P0y + 3 * t * Math.Pow((1 - t), 2) * P1y
                        + 3 * Math.Pow(t, 2) * (1 - t) * P2y + Math.Pow(t, 3) * P3y;


                    arrayForCheckX[i] = Math.Round(arrayX[i], 2);
                    arrayForCheckY[i] = Math.Round(arrayY[i]);

                    i++;
                }

                if (arrayForCheckX.Contains(P1xBefore) && arrayForCheckY[Array.IndexOf(arrayForCheckX, P1xBefore)] == Py)
                {
                    formsPlot1.plt.PlotScatter(arrayX, arrayY, color: Color.Black, markerSize: 0);
                    formsPlot1.plt.Axis(0, 7, 600, 1600);
                    formsPlot1.plt.AxisBounds(0, 7, 600, 1600);
                    formsPlot1.Render();
                    break;
                }
            }
            return new List<double[]> { arrayX, arrayY };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formsPlot1.plt.Clear();
            formsPlot1.Render();

            if (comboBox1.SelectedItem.Equals("2 точки"))
            {
                bezierBuilding(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox7.Text),
                    Convert.ToDouble(textBox8.Text));
            }
            else
            {
                bezierBuilding(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text),
                    Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox8.Text));
            }

            if (listOfLabels.Count() != 0)
            {
                for (int i = 0; i < listOfLabels.Count(); i++)
                {
                    if (listOfComboBoxes[i].SelectedItem.Equals("2 точки"))
                    {
                        bezierBuilding(Convert.ToDouble(listOfTextBoxes[(i * 8) + 0].Text), Convert.ToDouble(listOfTextBoxes[(i * 8) + 1].Text),
                            Convert.ToDouble(listOfTextBoxes[(i * 8) + 6].Text), Convert.ToDouble(listOfTextBoxes[(i * 8) + 7].Text));
                    }
                    else
                    {
                        bezierBuilding(Convert.ToDouble(listOfTextBoxes[(i * 8) + 0].Text), Convert.ToDouble(listOfTextBoxes[(i * 8) + 1].Text),
                            Convert.ToDouble(listOfTextBoxes[(i * 8) + 2].Text), Convert.ToDouble(listOfTextBoxes[(i * 8) + 3].Text),
                            Convert.ToDouble(listOfTextBoxes[(i * 8) + 6].Text), Convert.ToDouble(listOfTextBoxes[(i * 8) + 7].Text));
                    }
                }
            }
        }
    }
}
