using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp4.Models;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp4
{
    public partial class Form5 : Form
    {
        public const string CONNECTION_STRING = "Data Source=C:\\Users\\user\\Desktop\\NewDataBase.db";

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Извлечение значений из текстовых полей
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Проверка данных
            if (CheckUserCredentials(login, password))
            {
                MessageBox.Show("Успешная авторизация!");
                // Здесь вы можете открыть форму для авторизованных пользователей
                // Например:
              int id  =  GetUserInfo(login, password);
                Form1 Form1 = new Form1(id);
                Form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private bool CheckUserCredentials(string login, string password)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;
            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                // Поиск пользователя с указанными логином и паролем
                var user = dbContext.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
                return user != null;
            }
        }
        private int GetUserInfo(string login, string password)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;

            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                // Поиск пользователя с указанными логином и паролем
                var user = dbContext.Users.SingleOrDefault(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    return user.Id;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
