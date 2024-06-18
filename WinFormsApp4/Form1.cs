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
                return user?.IsAdmin == "�����"; // ��������������, ��� IsAdmin �������� ��� ������ "true"/"false"
            }
        }
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // ���������, ��� ��������� ��������� � ���������� ������ � �� � ��������� �������
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                Yahct modifiedYahct = dataGridView.Rows[e.RowIndex].DataBoundItem as Yahct;

                if (modifiedYahct != null)
                {
                    // �������� �������� ���������� ������
                    object newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // ����������, ����� �������� ������� Yahct ���� ��������
                    string propertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;

                    // �������� �������� ������� Yahct
                    typeof(Yahct).GetProperty(propertyName).SetValue(modifiedYahct, newValue);

                    // ��������� ��������� � ���� ������
                    SaveChangesToDatabase(modifiedYahct);
                    if (propertyName == "StatusWork" && newValue.ToString() == "������")
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

            // ���������� Form2 � ��������� ������
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
        //        // ������� ���� �� �� ID


        //        // ������� ������������ �� ��� ID
        //        var user = dbContext.Users.FirstOrDefault(u => u.OrderNumberId == yahctId);
        //        var yahct = dbContext.Yahcts.FirstOrDefault(y => y.Id == yahctId);

        //        if (user != null)
        //        {
        //            // �������� ����� ����������� ����� ������������
        //            string email = user.Email;

        //            // ����� ������ ���� ���������� �������� ��������� �� �����
        //            MessageBox.Show($"��������� ���������� �� �����: {email}");

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
                    // �������� ���������� ���������
                    string emailBody = $"����� ������: {yahct.Id}\n�������� �����: {yahct.Name}\n" +
                                       $"���������� ����: {yahct.NumberSeats}\n����: {yahct.Colour}\n" +
                                       $"������: {yahct.Model}\n��������: {yahct.Material}\n" +
                                       $"���. ������������: {yahct.DopEquipment}\n�����: {yahct.Machta}\n" +
                                       $"������ ������: {yahct.StatusWork}";

                    // �������� email ��� ��������
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
                                mailMessage.Subject = "������������� �����";
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

                    MessageBox.Show($"��������� ���������� �� �����: {user.Email}");
                  
                }
            }
        }







    }
}
