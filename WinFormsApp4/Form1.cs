using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Forms;
using WinFormsApp4.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Net.Mail;
using System.Net;
using Document = Microsoft.Office.Interop.Word.Document;



namespace WinFormsApp4
{

    public partial class Form1 : Form
    {
        public const string CONNECTION_STRING = "Data Source=C:\\Users\\user\\Desktop\\NewDataBase.db";
        public int UserId;
        public Form1(int userId)
        {
            InitializeComponent();
            loadInfo();
            dataGridView1.CellValueChanged += DataGridView_CellValueChanged;
            UserId = userId;
            if (!CheckIfUserIsAdmin(UserId))
            {
                dataGridView1.ReadOnly = true;
            }
           
        }
        public void loadInfo()
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;
            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {

                List<Yahct> yahcts = dbContext.Yahcts.ToList();


                BindingList<Yahct> bindingList = new BindingList<Yahct>(yahcts);


                dataGridView1.DataSource = bindingList;
                DataGridViewComboBoxColumn colourColumn = new DataGridViewComboBoxColumn();
                DataGridViewColumn column = dataGridView1.Columns["Colour"];
            }

        }
        private bool CheckIfUserIsAdmin(int userId)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;
            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                var user = dbContext.Users.SingleOrDefault(u => u.Id == userId);
                return user?.IsAdmin == "Админ"; // Предполагается, что IsAdmin хранится как строка "true"/"false"
            }
        }
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что изменение произошло в конкретной ячейке и не в заголовке столбца
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                Yahct modifiedYahct = dataGridView.Rows[e.RowIndex].DataBoundItem as Yahct;

                if (modifiedYahct != null)
                {
                    // Получаем значение измененной ячейки
                    object newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Определяем, какое свойство объекта Yahct было изменено
                    string propertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;

                    // Изменяем свойство объекта Yahct
                    typeof(Yahct).GetProperty(propertyName).SetValue(modifiedYahct, newValue);

                    // Сохраняем изменения в базу данных
                    SaveChangesToDatabase(modifiedYahct);
                    if (propertyName == "StatusWork" && newValue.ToString() == "Готово")
                    {
                        SendMessage(modifiedYahct.Id);
                    }
                }
            }
        }
        private void SaveChangesToDatabase(Yahct yahct)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                          .UseSqlite(connectionString)
                          .Options;
            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {

                dbContext.Entry(yahct).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(UserId);

            // Показываем Form2 в модальном режиме
            form2.Show();


            this.Hide();
        }
        //private void SendMessage(int yahctId)
        //{
        //    string connectionString = CONNECTION_STRING;
        //    var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
        //                    .UseSqlite(connectionString)
        //                    .Options;

        //    using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
        //    {
        //        // Находим яхту по ее ID


        //        // Находим пользователя по его ID
        //        var user = dbContext.Users.FirstOrDefault(u => u.OrderNumberId == yahctId);
        //        var yahct = dbContext.Yahcts.FirstOrDefault(y => y.Id == yahctId);

        //        if (user != null)
        //        {
        //            // Получаем адрес электронной почты пользователя
        //            string email = user.Email;

        //            // Здесь должна быть реализация отправки сообщения на почту
        //            MessageBox.Show($"Сообщение отправлено на адрес: {email}");

        //                this.Close();
        //        }
        //    }
        //}
        private void SendMessage(int yahctId)
        {
            string connectionString = CONNECTION_STRING;
            var options = new DbContextOptionsBuilder<CUsersuserDesktopNewDataBasedbContext>()
                            .UseSqlite(connectionString)
                            .Options;

            using (var dbContext = new CUsersuserDesktopNewDataBasedbContext(options))
            {
                var yahct = dbContext.Yahcts.FirstOrDefault(y => y.Id == yahctId);
                var user = dbContext.Users.FirstOrDefault(u => u.OrderNumberId == yahctId);

                if (yahct != null && user != null)
                {
                    // Создание текстового сообщения
                    string emailBody = $"Номер заказа: {yahct.Id}\nНазвание лодки: {yahct.Name}\n" +
                                       $"Количество мест: {yahct.NumberSeats}\nЦвет: {yahct.Colour}\n" +
                                       $"Модель: {yahct.Model}\nМатериал: {yahct.Material}\n" +
                                       $"Доп. оборудование: {yahct.DopEquipment}\nМачта: {yahct.Machta}\n" +
                                       $"Статус работы: {yahct.StatusWork}";

                    // Отправка email без вложения
                    string smtpServer = "smtp.yandex.ru";
                    int smtpPort = 587;
                    string smtpUsername = "ahmedmaiorov@yandex.ru";
                    string smtpPassword = "kiplmcaohoymmihb";

                    using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        smtpClient.EnableSsl = true;

                        using (System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage())
                        {
                            try
                            {
                                mailMessage.From = new MailAddress(smtpUsername, "Boats");
                                mailMessage.To.Add("rand123456deart@mail.ru");
                                mailMessage.Subject = "Подтверждение почты";
                                mailMessage.IsBodyHtml = true;
                                mailMessage.Body = emailBody;

                                smtpClient.Send(mailMessage);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }

                    MessageBox.Show($"Сообщение отправлено на адрес: {user.Email}");
                  
                }
            }
        }







    }
}
