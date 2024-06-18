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
using WinFormsApp4.Models;

namespace WinFormsApp4
{
    partial class Form2 : Form
    {
        public const string CONNECTION_STRING = "Data Source=C:\\Users\\user\\Desktop\\NewDataBase.db";
        public int userId;
        public Form2(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Извлечение выбранных значений из ComboBox-ов
            string value1 = comboBox1.SelectedItem.ToString();
            string value2 = comboBox2.SelectedItem.ToString();
            string value3 = comboBox3.SelectedItem.ToString();
            string value4 = comboBox4.SelectedItem.ToString();
            string value5 = comboBox5.SelectedItem.ToString();

            // Создание нового объекта Yahct с извлеченными значениями
            Yahct newYahct = new Yahct
            {
                Colour = value1,
                Model = value2,
                Name = "Яхта",
                NumberSeats = 5,
                Material = value3,
                DopEquipment = value4,
                Machta = value5,
                StatusWork = "Работы не начаты"


            };
          
            // Сохранение нового объекта Yahct в базе данных
            SaveChangesToDatabase(newYahct);
            NextPage();
        }
        private void SaveChangesToDatabase(Yahct yahct)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;
            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                dbContext.Yahcts.Add(yahct); // Используйте Add для новой записи
                dbContext.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(userId);

            // Показываем Form2 в модальном режиме
            form1.ShowDialog();


            this.Close();
        }
        private void NextPage()
        {
            Form3 form3 = new Form3(userId);

            // Показываем Form2 в модальном режиме
            form3.Show();


            this.Close();
        }
    }
}
