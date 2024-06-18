using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsApp4.Models;

namespace WinFormsApp4
{
    public partial class Form4 : Form
    {
        public const string CONNECTION_STRING = "Data Source=C:\\Users\\user\\Desktop\\NewDataBase.db";
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Извлечение выбранных значений из ComboBox-ов
            string value1 = textBox1.Text;
            string value2 = textBox2.Text;
            string value3 = comboBox1.Text;

            // Создание нового объекта Yahct с извлеченными значениями
            User newUser = new User
            {
                Login = value1,
                Password = value2,
                IsAdmin = value3


            };
            
          
            SaveChangesToDatabase(newUser);
            Form5 form5 = new Form5();

            // Показываем Form2 в модальном режиме
            form5.Show();


            this.Hide();
        }
        private void SaveChangesToDatabase(User newUser)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;
            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                dbContext.Users.Add(newUser); // Используйте Add для новой записи
                dbContext.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5= new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
