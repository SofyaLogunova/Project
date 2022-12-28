using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace KUSKo
{
    public partial class frmMain : Form
    {
       
        public frmMain()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt";

        }
        // -----------------------------------------Почта-----------------------------------
        private void btnSend_Click(object sender, EventArgs e)


        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("logunova_sofya@yandex.ru", "logun0va.sof");
            // кому отправляем,
            MailAddress to = new MailAddress("logunova_sofya@inbox.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = txtSubject.Text;
            // текст письма
            m.Body = txtMassage.Text;
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("localhost", 25);
            // логин и пароль
            smtp.Send(m);
            Console.Read();
        }
        private void txtTo_TextChanged(object sender, EventArgs e)
        {

        }

        // -----------------------------------------Почта-----------------------------------




        // -----------------------------------------Контакты-----------------------------------
        string connectionString = @"Data Source=DESKTOP-FB19LNS;Initial Catalog=Contact;Integrated Security=True";
        int ID = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "" && txtContact.Text.Trim() != "")
            {
                Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = reg.Match(txtEMail.Text.Trim());
                if (match.Success)
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ContactAddEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ID", ID);
                        sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", txtEMail.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Submitted Successfully");
                        Clear();
                        GridFill();

                    }
                }
                else
                    MessageBox.Show("Email Address is not Valid");
            }
            else
                MessageBox.Show("Please Fill Mandatory Fields.");
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtEMail.Text = txtAddress.Text = txtSearch.Text = "";
            ID = 0;
            btnSave.Text = "Save";
            btnDelete.Enabled = false;

        }
        void GridFill()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewAll", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dgvPhoneBook.DataSource = dtbl;
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("ContactDeleteByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", ID);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully");
                Clear();
                GridFill();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GridFill();
            btnDelete.Enabled = false;
        }

        private void dgvPhoneBook_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPhoneBook.CurrentRow.Index != -1)
            {
                txtFirstName.Text = dgvPhoneBook.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = dgvPhoneBook.CurrentRow.Cells[2].Value.ToString();
                txtContact.Text = dgvPhoneBook.CurrentRow.Cells[3].Value.ToString();
                txtEMail.Text = dgvPhoneBook.CurrentRow.Cells[4].Value.ToString();
                txtAddress.Text = dgvPhoneBook.CurrentRow.Cells[5].Value.ToString();
                ID = Convert.ToInt32(dgvPhoneBook.CurrentRow.Cells[0].Value.ToString());

                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ContactSEarchByID", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@Search", txtSearch.Text.Trim());
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dgvPhoneBook.DataSource = dtbl;
            }
        }
        // -----------------------------------------Контакты-----------------------------------



        // -----------------------------------------Заметки-----------------------------------
        string connectionStringZametky = @"Data Source=DESKTOP-FB19LNS;Initial Catalog=Zametcy;Integrated Security=True";
        int IDZametky = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTopic.Text.Trim() != "" && txtBox.Text.Trim() != "")
            {
                    using (SqlConnection sqlCon = new SqlConnection(connectionStringZametky))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ZametkyAddEdit", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ZametkyID", IDZametky);
                        sqlCmd.Parameters.AddWithValue("@Topic", txtTopic.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Box", txtBox.Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        MessageBox.Show("Submitted Successfully");
                        ClearZam();
                        GridFillZam();

                    }
            }
            else
                MessageBox.Show("Please Fill Mandatory Fields.");
        }
        void ClearZam()
        {
            txtTopic.Text = txtBox.Text  = "";
            IDZametky = 0;
            btnSaveZam.Text = "Save";
            btnDeleteZam.Enabled = false;

        }

        void GridFillZam()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionStringZametky))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ZametkyViewAll", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblZam = new DataTable();
                sqlDa.Fill(dtblZam);
                dtBox.DataSource = dtblZam;
            }

        }

        private void btnCleartZam_Click(object sender, EventArgs e)
        {
            ClearZam();
        }

        private void btnDeleteZam_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionStringZametky))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("ZametkyDeleteByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ZametkyID", IDZametky);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully");
                ClearZam();
                GridFillZam();

            }
        }

        private void dtBox_DoubleClick(object sender, EventArgs e)
        {
            if (dtBox.CurrentRow.Index != -1)
            {
                txtTopic.Text = dtBox.CurrentRow.Cells[1].Value.ToString();
                txtBox.Text = dtBox.CurrentRow.Cells[2].Value.ToString();
                IDZametky = Convert.ToInt32(dtBox.CurrentRow.Cells[0].Value.ToString());

                btnSaveZam.Text = "Update";
                btnDeleteZam.Enabled = true;
            }
        }
        // -----------------------------------------Заметки-----------------------------------


        // -----------------------------------------Блокнот-----------------------------------
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
                string filename = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filename);
                richTextBox1.Text = fileText;
                MessageBox.Show("Файл открыт");


            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
                string filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, richTextBox1.Text);
                MessageBox.Show("Файл сохранён");
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // -----------------------------------------Блокнот-----------------------------------
}

