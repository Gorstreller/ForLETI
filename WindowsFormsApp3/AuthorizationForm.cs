using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Проверяем логин и пароль
            if (loginTextBox.Text == "login" && passwordTextBox.Text == "1234")
            {
                // Убираем warning, если он есть
                warningLabel.Visible = false;
                // Закрываем данную форму и выводим форму добавления новой диаграммы
                Close();
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                warningLabel.Visible = true;
            }
        }

    }
}
