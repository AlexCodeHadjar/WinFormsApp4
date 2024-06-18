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
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp4
{
    public partial class Form3 : Form
    {
        public const string CONNECTION_STRING = "Data Source=C:\\Users\\user\\Desktop\\NewDataBase.db";
        public int UserId;
        public Form3(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
            LoadUserData(UserId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(UserId);

            // Показываем Form2 в модальном режиме
            form2.Show();


            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Извлечение выбранных значений из ComboBox-ов
            string surName = textBox1.Text;
            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            string dateBirth = textBox4.Text;
            string address = textBox5.Text;
            string phoneNumber = textBox6.Text;
            string email = textBox7.Text;
            string passport = textBox8.Text;
            int userId = UserId;



            // Создание нового объекта Yahct с извлеченными значениями








            // Сохранение нового объекта Yahct в базе данных
            UpdateUserInDatabase(userId, surName, firstName, lastName, passport, dateBirth, address, phoneNumber, email);
            NextPage();

        }
        private void UpdateUserInDatabase(int userId, string surName, string firstName, string lastName, string passport, string dateBirth, string address, string phoneNumber, string email)
        {
            string connectionString = CONNECTION_STRING; // Замените на вашу фактическую строку подключения
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;

            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                // Поиск существующего пользователя по уникальному идентификатору (например, Id)
                var existingUser = dbContext.Users.SingleOrDefault(user => user.Id == userId);

                var lastYacht = dbContext.Yahcts.OrderByDescending(y => y.Id).FirstOrDefault();
                if (lastYacht != null)
                {
                    existingUser.OrderNumberId = lastYacht.Id;
                }

                if (existingUser != null)
                {
                    // Обновление свойств пользователя новыми значениями
                    existingUser.SurName = surName;
                    existingUser.FirstName = firstName;
                    existingUser.LastName = lastName;
                    existingUser.Passport = passport;
                    existingUser.DateBirth = dateBirth;
                    existingUser.Address = address;
                    existingUser.PhoneNumber = phoneNumber;
                    existingUser.Email = email;


                    // Сохранение изменений в базе данных
                    dbContext.SaveChanges();
                }
                else
                {
                    // Обработка ситуации, когда пользователь не найден
                    MessageBox.Show("Пользователь с указанным ID не найден.");
                }
            }
        }
        private void LoadUserData(int userId)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;

            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                // Поиск существующего пользователя по ID
                var existingUser = dbContext.Users.SingleOrDefault(user => user.Id == userId);

                if (existingUser != null)
                {
                    // Заполнение текстовых полей значениями из базы данных
                    textBox1.Text = existingUser.SurName;
                    textBox2.Text = existingUser.FirstName;
                    textBox3.Text = existingUser.LastName;
                    textBox4.Text = existingUser.Passport;
                    textBox5.Text = existingUser.DateBirth;
                    textBox6.Text = existingUser.Address;
                    textBox7.Text = existingUser.PhoneNumber;
                    textBox8.Text = existingUser.Email;
                }
            }
        }
        public void NextPage()
        {
            Form1 form1 = new Form1(UserId);
            form1.Show();
            this.Hide();
        }

     
    }
}
